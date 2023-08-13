using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 targetPos;
    Animator animator;
    bool isWalking;
    bool isClicking;
    float defaultSpeed;
    float gimmickSize;

    [SerializeField] bool exitLimit;
    [SerializeField] Transform leftPos;
    [SerializeField] Transform rightPos;
    [SerializeField] GameObject emoticon;

    enum FaceDirection
    {
        Right,
        Left,
    };
    FaceDirection faceDirection = FaceDirection.Right;


    enum Mode
    {
        Busy,
        Normal,
        ReachGimmick,
        Push,
        Kick,
        PushSwitch,
    }

    Mode mode = Mode.Normal;
    Gimmick gimmick;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        defaultSpeed = speed;
        targetPos = transform.position;
    }


    // クリックしたものの近くまでいく
    // クリックしたものが「動かすもの」ならモードを「PrePush」に変更
    // クリックしたものが「キック」ならモードを「PrePush」に変更

    // クリックした場所まで移動
    private void Update()
    {
        if (GameManager.Instance.IsGameClear)
        {
            return;
        }
        if (mode == Mode.Busy)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            Vector3 touchScreenPosition = Input.mousePosition;
            touchScreenPosition.z = 5.0f;
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(touchScreenPosition);



            if (hit2d)
            {
                if (gimmick)
                {
                    return;
                }

                // ギミックを取得
                gimmick = hit2d.transform.GetComponent<Gimmick>();
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
                }
            }
            else if (gimmick && mode == Mode.Push && ((faceDirection == FaceDirection.Right && clickPos.x < gimmick.transform.position.x) || (faceDirection == FaceDirection.Left && clickPos.x > gimmick.transform.position.x)))
            {
                // 進行方向と逆をクリックしたら
                animator.SetTrigger("OnNormal");
                mode = Mode.Normal;
                gimmick = null;
            }
            else if (gimmick && mode != Mode.Push)
            {
                animator.SetTrigger("OnNormal");
                mode = Mode.Normal;
                gimmick = null;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClicking = false;
        }
        

        if (!isClicking &&(mode == Mode.Normal || mode == Mode.Push))
        {
            if (Input.GetMouseButton(0))
            {
                SetTarget();
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
        }
    }

    private void LateUpdate()
    {
        // この時にPrePshならPushに移行
        // キックならキックに移行
        if (!isWalking && mode == Mode.ReachGimmick)
        {
            mode = Mode.Busy;
            SetDirection(gimmick.transform.position);
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

    public void KickGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        animator.Play("Kick");
        mode = Mode.Kick;
    }
    public void PushButtonGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        animator.Play("Switch_R");

        //if (gimmick.transform.position.x < transform.position.x)
        //{
        //    animator.Play("Switch_L");
        //}
        //else
        //{
        //    animator.Play("Switch_R");
        //}

        mode = Mode.PushSwitch;
    }

    public void PushLeverButtonGimmick()
    {
        isWalking = false;
        animator.SetBool("IsWalking", isWalking);
        animator.Play("Lever");
        mode = Mode.PushSwitch;
    }


    public void ShowQuestionEmotion()
    {
        StartCoroutine(ShowEmotion());
    }

    IEnumerator ShowEmotion()
    {
        SetDefaultMode();
        yield return new WaitForSeconds(0.7f);
        emoticon.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        emoticon.gameObject.SetActive(false);
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
        if (exitLimit)
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
        animator.SetBool("IsWalking", isWalking);
        targetPos = transform.position;
    }
}