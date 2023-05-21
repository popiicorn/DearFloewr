using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] Vector3 targetPos;
    Animator animator;
    bool isWalking;
    bool isClicking;

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
        PrePush,
        Push,
    }

    Mode mode = Mode.Normal;
    GameObject pushObj;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        targetPos = transform.position;
    }
    // クリックした場所まで移動
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            Vector3 touchScreenPosition = Input.mousePosition;
            touchScreenPosition.z = 5.0f;
            Vector3 clickPos = Camera.main.ScreenToWorldPoint(touchScreenPosition);

            if (hit2d)
            {
                Gimmick gimmick = hit2d.transform.GetComponent<Gimmick>();
                if (gimmick != null)
                {
                    isClicking = true;
                    gimmick.OnClickAction();
                    mode = Mode.PrePush;
                    // targetPos = hit2d.transform.position;
                    targetPos = gimmick.GetTargetPosition(transform.position).position;

                    pushObj = hit2d.transform.gameObject;
                }
            }
            else if (pushObj && ((faceDirection == FaceDirection.Right && clickPos.x < pushObj.transform.position.x) || (faceDirection == FaceDirection.Left && clickPos.x > pushObj.transform.position.x)) )
            {
                // 進行方向と逆をクリックしたら
                animator.SetTrigger("OnNormal");
                mode = Mode.Normal;
                pushObj = null;
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
        if (pushObj && mode == Mode.Push)
        {
            pushObj.transform.position += transform.position - prePos;
        }
        SetDirection(targetPos);

        isWalking = (transform.position - targetPos).sqrMagnitude >= float.Epsilon;

    }

    private void LateUpdate()
    {
        if (!isWalking && mode == Mode.PrePush)
        {
            animator.SetTrigger("Push");
            mode = Mode.Push;
            SetDirection(pushObj.transform.position);
        }
        else if (mode == Mode.Normal || mode == Mode.PrePush)
        {
            animator.SetBool("IsWalking", isWalking);
        }
    }

    void SetTarget()
    {
        Vector3 touchScreenPosition = Input.mousePosition;
        touchScreenPosition.z = 5.0f;
        targetPos = Camera.main.ScreenToWorldPoint(touchScreenPosition);
        targetPos.z = transform.position.z;
        targetPos.y = transform.position.y;
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
    }
}