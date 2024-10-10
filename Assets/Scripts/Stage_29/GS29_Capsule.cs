using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS29_Capsule : MonoBehaviour
{
    // ������Ƀ����_���ɗ͂�������

    Rigidbody2D rb;
    [SerializeField] float force = 10f;
    [SerializeField] float torque = 10f;
    bool canAddForce = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    public void AddForce()
    {
        if (!canAddForce) return;

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        rb.AddTorque(torque, ForceMode2D.Impulse);
    }

    public void StopForce()
    {
        canAddForce = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.gravityScale = 0;
        rb.isKinematic = true;
    }

    public void ResetForce()
    {
        canAddForce = true;
    }

    public void OnClick()
    {
        rb.isKinematic = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        CriManager.instance.PlayObjSE("CupcellHop");
        // isGrounded = true;
    }

    //private void Update()
    //{
    //    // ��葬�x�ŉ�]���Ă���΁A����炷
    //    if (Mathf.Abs(rb.angularVelocity) > 50 && isGrounded)
    //    {
    //        CriManager.instance.PlayObjSE("CupcellHop");
    //    }
    //}
    //bool isGrounded = false;

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    isGrounded = false;
    //}
}
