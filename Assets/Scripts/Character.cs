using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] Vector3 targetPos;
    Animator animator;
    bool isWalking;

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
        if (Input.GetMouseButton(0))
        {
            SetTarget();
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        SetDirection();

        isWalking = (transform.position - targetPos).sqrMagnitude >= float.Epsilon;
    }

    private void LateUpdate()
    {
        animator.SetBool("IsWalking", isWalking);
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