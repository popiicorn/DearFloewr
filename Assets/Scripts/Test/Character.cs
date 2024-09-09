using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    [SerializeField]
    float speed = 3;
    Vector3 targetPos;
    Animator animator;
    bool isWalking;
    bool isClicking;
    float defaultSpeed;
    float gimmickSize;
    public bool canMove = true;
    public bool canClick = true;

    [SerializeField] bool exitLimit;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    Transform initLeftPos;
    Transform initRightPos;
    [SerializeField] GameObject emoticon;
    [SerializeField] GameObject emoticonv2;

    enum FaceDirection
    {
        Right,
        Left,
    };
    FaceDirection faceDirection = FaceDirection.Right;


    public enum Mode
    {
        Busy,
        Normal,
        ReachGimmick,
        Push,
        Kick,
        PushSwitch,
        Sit,
    }

    Mode mode = Mode.Normal;
    [SerializeField] Gimmick gimmick;

    public bool ExitLimit { get => exitLimit; set => exitLimit = value; }
    public Mode CharaMode { get => mode; }

    public void SetExitLimit(bool value)
    {
        exitLimit = value;
    }

    public void ResetLimit(Transform tf)
    {
        leftPos = tf;
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        defaultSpeed = speed;
        targetPos = transform.position;
        initLeftPos = leftPos;
        initRightPos = rightPos;
    }

    public void SetParams(float speed)
    {
        this.speed = speed;
    }

    public void SetLimitObj(Transform left, Transform right)
    {
        leftPos = left;
        rightPos = right;
    }


    // クリックしたものの近くまでいく
    // クリックしたものが「動かすもの」ならモードを「PrePush」に変更
    // クリックしたものが「キック」ならモードを「PrePush」に変更

    // クリックした場所まで移動
    private void Update()
    {

        if (GameManager.Instance.IsGameClear && !GameManager.Instance.IsCamMoveCleared)
        {
            return;
        }
        if (mode == Mode.Busy || mode == Mode.PushSwitch)
        {
            transform.localScale = new Vector3(1, 1, 1);
            return;
        }
        if (!canMove)
        {
            if (mode == Mode.Normal)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faceDirection = FaceDirection.Left;
            }
            return;
        }
        if (mode == Mode.Kick)
        {
            return;
        }

        if (GameManager.Instance.IsOptionPanelActive) return;

        if (Input.GetMouseButtonDown(0) && canClick)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            Vector3 touchScreenPosition = Input.mousePosition;
            touchScreenPosition.z = 5.0f;
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(touchScreenPosition);


            
            if (hit2d)
            {
                if (gimmick && isWalking)
                {
                    return;
                }
                animator.Play("Idle");
                // ギミックを取得
                gimmick = hit2d.transform.GetComponent<Gimmick>();
                Debug.Log(gimmick);
                if (gimmick && gimmick.IsLock)
                {
                    gimmick = null;
                    return;
                }
                if (gimmick)
                {
                    isClicking = true;
                    mode = Mode.ReachGimmick;
                    
                    targetPos = gimmick.GetTargetPosition(transform.position).position;
                    if (gimmick.isLimit)
                    {
                        SetLimitObj(gimmick.GetLeftLimit(), gimmick.GetRightLimit());
                        // gimmick.OnLimit = StopMode;
                    }
                }
            }
            else if (gimmick && mode == Mode.Push && ((faceDirection == FaceDirection.Right && clickPos.x < gimmick.CenterTransform.position.x) || (faceDirection == FaceDirection.Left && clickPos.x > gimmick.CenterTransform.position.x)))
            {
                // 進行方向と逆をクリックしたら
                animator.SetTrigger("OnNormal");
                mode = Mode.Normal;
                gimmick = null;
                CriManager.instance.StopSE();
                SetLimitObj(initLeftPos, initRightPos);
            }
            else if (gimmick && mode != Mode.Push)
            {
                animator.SetTrigger("OnNormal");
                mode = Mode.Normal;
                gimmick = null;
                SetLimitObj(initLeftPos, initRightPos);
            }
        }


        if (Input.GetMouseButtonUp(0))
        {
            isClicking = false;
        }
        

        if (!isClicking && CheckCanWalkMode())
        {
            if (Input.GetMouseButton(0))
            {
                SetTarget();
                if (gimmick && mode == Mode.Push && ((faceDirection == FaceDirection.Right && targetPos.x < gimmick.CenterTransform.position.x) || (faceDirection == FaceDirection.Left && targetPos.x > gimmick.CenterTransform.position.x)))
                {
                    animator.SetTrigger("OnNormal");
                    mode = Mode.Normal;
                    gimmick.CenterTransform.position = new Vector3(targetPos.x, gimmick.CenterTransform.position.y, 0);

                    gimmick = null;
                    CriManager.instance.StopSE();
                    SetLimitObj(initLeftPos, initRightPos);


                }
                if (mode == Mode.Sit)
                {
                    animator.SetTrigger("OnNormal");
                    mode = Mode.Normal;
                    gimmick = null;
                    SetLimitObj(initLeftPos, initRightPos);
                }
            }
            if (mode == Mode.Push && gimmick && gimmick.IsMove)
            {
                if (gimmick && mode == Mode.Push && ((faceDirection == FaceDirection.Right && targetPos.x < gimmick.CenterTransform.position.x) || (faceDirection == FaceDirection.Left && targetPos.x > gimmick.CenterTransform.position.x)))
                {
                    Debug.Log("PushMode22222");
                    animator.SetTrigger("OnNormal");
                    mode = Mode.Normal;
                    gimmick = null;
                    CriManager.instance.StopSE();
                    SetLimitObj(initLeftPos, initRightPos);
                }
            }
        }



        targetPos.z = transform.position.z;
        targetPos.y = transform.position.y;
        Vector3 prePos = transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (gimmick && mode == Mode.Push)
        {
            gimmick.Move(transform.position - prePos);
        }
        SetDirection(targetPos);


        isWalking = (transform.position - targetPos).sqrMagnitude >= float.Epsilon;

        if (isWalking)
        {
            if (mode == Mode.Push)
            {
                speed = defaultSpeed / 2f;
                CriManager.instance.PlayPushSE();
            }
            else if (mode == Mode.Normal)
            {
                speed = defaultSpeed;
            }
            if (emoticon.activeSelf)
            {
                emoticon.SetActive(false);
            }
        }
        else if(mode == Mode.Normal)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceDirection = FaceDirection.Left;
            // CriManager.instance.StopSE();
        }
        else
        {
            // CriManager.instance.StopSE();
        }
    }


    bool CheckCanWalkMode()
    {
        switch (mode)
        {
            case Mode.Normal:
            case Mode.Push:
            case Mode.Sit:
                return true;
            default:
                return false;
        }
    }

    private void LateUpdate()
    {
        // この時にPrePshならPushに移行
        // キックならキックに移行
        if (!isWalking && mode == Mode.ReachGimmick)
        {
            mode = Mode.Busy;
            SetDirection(gimmick.CenterTransform.position);
            gimmick.OnGameCharacter(this);
        }
        else if (mode == Mode.Normal || mode == Mode.ReachGimmick || mode == Mode.Push)
        {
            animator.SetBool("IsWalking", isWalking);
        }
    }

    public void BusyMode()
    {
        mode = Mode.Busy;
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        targetPos = transform.position;
    }

    public void SetTarget(Vector3 pos)
    {
        Vector3 currentPos = transform.position;
        currentPos.x = pos.x;
        targetPos = currentPos;
    }

    public void KickGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        if (faceDirection == FaceDirection.Left)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        animator.Play("Kick");
        mode = Mode.Kick;
    }
    public void PushButtonGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        if (faceDirection == FaceDirection.Left)
        {
            animator.Play("Switch_R");
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("Switch_L");
        }

        mode = Mode.PushSwitch;
    }

    public void PushLeverButtonGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        animator.Play("Lever");
        mode = Mode.PushSwitch;
    }

    // 座るアニメーションをする
    public void SitGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        animator.Play("Sit");
        mode = Mode.Sit;
        transform.localScale = new Vector3(1, 1, 1);
        SteamAchievementManager.Instance.UnlockAchievement("ACHIEVEMENT_1");
    }

    public void ShowQuestionEmotion()
    {
        StopAllCoroutines();
        StartCoroutine(ShowEmotion());
    }

    public void ShowEmotion2V()
    {
        StopAllCoroutines();
        StartCoroutine(Emotion2V());
    }

    IEnumerator Emotion2V()
    {
        canMove = false;
        SetDefaultMode();
        yield return new WaitForSeconds(0.7f);
        emoticonv2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        emoticonv2.gameObject.SetActive(false);
        canMove = true;
    }


    public void ShowNockAnim(bool isRight)
    {
        if (isRight)
        {
            animator.Play("knock_R");
        }
        else
        {
            animator.Play("knock_L");
        }
    }

    public void SetWalkBackAnim()
    {
        animator.Play("WalkBack");
    }

    IEnumerator ShowEmotion()
    {
        canMove = false;
        SetDefaultMode();
        yield return new WaitForSeconds(0.7f);
        emoticon.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        emoticon.gameObject.SetActive(false);
        canMove = true;
    }

    public void SetPushMode()
    {
        //isWalking = false;
        //animator.SetBool("IsWalking", false);
        animator.SetTrigger("Push");
        mode = Mode.Push;
    }



    void SetTarget()
    {
        Vector3 touchScreenPosition = Input.mousePosition;
        touchScreenPosition.z = 5.0f;
        targetPos = Camera.main.ScreenToWorldPoint(touchScreenPosition);
        targetPos.z = transform.position.z;
        targetPos.y = transform.position.y;
        float offsetX = 0;
        if (mode == Mode.Push && gimmick)
        {
            offsetX = gimmick.Size*2f;
        }
        if (gimmick && gimmick.isLimit)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, leftPos.position.x + gimmick.limitOffsetL, rightPos.position.x - gimmick.limitOffsetR);
        }
        else if (exitLimit)
        {
            targetPos.x = Mathf.Clamp(targetPos.x, leftPos.position.x + offsetX, rightPos.position.x - offsetX);
        }
    }

    void SetDirection(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceDirection = FaceDirection.Left;
        }
        else if(target.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            faceDirection = FaceDirection.Right;
        }

        if (!isWalking && mode == Mode.Normal)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceDirection = FaceDirection.Left;
        }
    }

    public void SetDefaultMode()
    {
        mode = Mode.Normal;
        isClicking = false;
        gimmick = null;
        isWalking = false;
        animator.SetTrigger("OnNormal");
        speed = defaultSpeed;
        animator.SetBool("IsWalking", isWalking);
        targetPos = transform.position;
        SetLimitObj(initLeftPos, initRightPos);
        if (CriManager.instance)
        {
            CriManager.instance.StopSE();
        }
    }

    public void SetAnim(AnimatorOverrideController animatorOverrideController)
    {
        animator.runtimeAnimatorController = animatorOverrideController;
    }
}