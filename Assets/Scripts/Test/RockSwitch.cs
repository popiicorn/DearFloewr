using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RockSwitch : MonoBehaviour
{
    [SerializeField] GameObject clearObj;
    public UnityEvent ClearEvent;
    // もしRockがぶつかったら
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponentInParent<Rock>().SetLock(true);
        clearObj.SetActive(true);
        ClearEvent?.Invoke();
        GameManager.Instance.GameClear();
    }
}
