using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
// マウスでドラッグ&ドロップできるようにする
public class GS_31_Key : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // オフセットを作って、クリックした位置との差分を保持する
    Vector3 offset;
    // Dropできるようにする
    CanvasGroup canvasGroup;
    [SerializeField] GameObject effect;
    [SerializeField] EventData[] onBeginDrag;


    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        // クリックした位置と、オブジェクトの位置の差分を保持する
        offset = transform.position - Camera.main.ScreenToWorldPoint(eventData.position);
        StartCoroutine(PlayEvent());
    }

    IEnumerator PlayEvent()
    {
          foreach (var eventData in onBeginDrag)
        {
            yield return eventData.Play();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // CanvasのRenderModeがScreenSpace - Cameraの場合、
        // eventData.positionはカメラのスクリーン座標なので、
        // カメラのワールド座標に変換する
        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        screenToWorldPoint.z = 0;

        // オブジェクトの位置を、クリックした位置とオフセットを足した位置にする
        transform.position = screenToWorldPoint + offset;
        // Canvasの画面外に出ないようにする。LocalPositionで判定する
        Vector3 localPosition = transform.localPosition;
        float buff = 100f;
        // 画面サイズによって変える必要がある
        localPosition.x = Mathf.Clamp(localPosition.x, -Screen.width/2f+ buff, Screen.width / 2f- buff);
        localPosition.y = Mathf.Clamp(localPosition.y, -Screen.height / 2f + buff, Screen.height / 2f- buff);
        transform.localPosition = localPosition;




    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
    }
    
    // エフェクトを非表示
    public void OnSetKey()
    {
        effect.SetActive(false);
    }
}
