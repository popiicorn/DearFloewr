using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS11_AutoMove : MonoBehaviour
{
    public float speed = 3;
    Vector3 targetPos;
    bool isMoving = false;
    bool isWalking = false;
    Animator animator;

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
    public Mode mode = Mode.Normal;
    enum FaceDirection
    {
        Right,
        Left,
    };
    FaceDirection faceDirection = FaceDirection.Right;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isMoving)
        {
            targetPos.z = transform.position.z;
            targetPos.y = transform.position.y;
            Vector3 prePos = transform.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            SetDirection(targetPos);
            isWalking = (transform.position - targetPos).sqrMagnitude >= float.Epsilon;

            animator.SetBool("IsWalking", isWalking);
        }
    }

    private void LateUpdate()
    {
        
    }

    void SetDirection(Vector3 target)
    {
        if (target.x < transform.position.x)
        {
            transform.localScale = new Vector3(1, 1, 1);
            faceDirection = FaceDirection.Left;
        }
        else if (target.x > transform.position.x)
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

    public void SetTarget(Vector3 pos)
    {
        Vector3 currentPos = transform.position;
        currentPos.x = pos.x;
        targetPos = currentPos;
        isMoving = true;
    }

    public void SetDefaultMode()
    {
        mode = Mode.Normal;
        isWalking = false;
        animator.SetTrigger("OnNormal");
        animator.SetBool("IsWalking", isWalking);
        targetPos = transform.position;
        if (CriManager.instance)
        {
            CriManager.instance.StopSE();
        }
    }

}
