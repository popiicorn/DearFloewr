using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] Vector3 targetPos;
    Animator animator;
    bool isWalking;
    enum Mode
    {
        Normal,
        PrePush,
        Push,
    }

    Mode mode = Mode.Normal;

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

            if (hit2d)
            {
                Gimmick gimmick = hit2d.transform.GetComponent<Gimmick>();
                if (gimmick != null)
                {
                    gimmick.OnClickAction();

                    mode = Mode.PrePush;
                    targetPos = gimmick.GetTargetPosition(transform.position).position;
                }
            }
            else
            {
                animator.SetTrigger("OnNormal");
                mode = Mode.Normal;
            }
        }
        if (mode == Mode.Normal)
        {
            if (Input.GetMouseButton(0))
            {
                SetTarget();
            }
        }
        targetPos.z = transform.position.z;
        targetPos.y = transform.position.y;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        SetDirection();

        isWalking = (transform.position - targetPos).sqrMagnitude >= float.Epsilon;

    }

    private void LateUpdate()
    {
        if (!isWalking && mode == Mode.PrePush)
        {
            animator.SetTrigger("Push");
        }
        else
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

    void SetDirection()
    {
        if (targetPos.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(targetPos.x > transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}