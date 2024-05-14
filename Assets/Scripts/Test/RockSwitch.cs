using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockSwitch : MonoBehaviour
{
    [SerializeField] int id;
    [SerializeField] CameraShake cameraShake;
    public UnityEvent ClearEvent;
    // もしRockがぶつかったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IRockable rock = collision.GetComponentInParent<IRockable>();
        if (rock != null &&  rock.Id == id)
        {
            rock.SetLock(true);
            //設置
            ClearEvent?.Invoke();
            if (cameraShake)
            {
                StartCoroutine(cameraShake.Shake(0.02f, 0.7f, 10f / 60f));
            }
        }
    }
}
