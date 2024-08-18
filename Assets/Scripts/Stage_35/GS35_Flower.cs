using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GS35_Flower : MonoBehaviour
{
    [SerializeField] GameObject flowerObj;
    [SerializeField] GameObject effect;
    bool isClicked = false;
    public UnityAction OnClickAction;

    public bool IsClicked { get => isClicked; }

    public void OnClick()
    {
        isClicked = true;
        flowerObj.SetActive(false);
        effect.SetActive(true);
        OnClickAction.Invoke();
        // StartCoroutine(CursorAnim());
    }


    IEnumerator CursorAnim()
    {
        // マウスカーソルを非表示にする
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        yield return new WaitForSeconds(2.9f);
        // マウスカーソルを表示する
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
