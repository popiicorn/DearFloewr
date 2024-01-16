using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockSwitch : MonoBehaviour
{
    [SerializeField] int id;
    public UnityEvent ClearEvent;
    // もしRockがぶつかったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null &&  rock.Id == id)
        {
            collision.GetComponentInParent<IRockable>().SetLock(true);
            //設置
            ClearEvent?.Invoke();
        }
    }
}
