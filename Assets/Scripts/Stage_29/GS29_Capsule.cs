using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS29_Capsule : MonoBehaviour
{
    // è„ï˚å¸Ç…ÉâÉìÉ_ÉÄÇ…óÕÇâ¡Ç¶ÇÈ

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
}
