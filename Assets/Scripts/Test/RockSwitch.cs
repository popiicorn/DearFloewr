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
        Rock rock = collision.GetComponentInParent<Rock>();
        if (rock && rock.Id == id)
        {
            collision.GetComponentInParent<Rock>().SetLock(true);
            //設置
            ClearEvent?.Invoke();
        }
    }
}
