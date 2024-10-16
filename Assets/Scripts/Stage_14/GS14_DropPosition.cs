using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
public class GS14_DropPosition : MonoBehaviour, IDropHandler
{
    [SerializeField] GS14_Parts part;
    [SerializeField] float correctAngle = 0f;
    [SerializeField] GameObject clearPart;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GS14_Parts dragPart = eventData.pointerDrag.GetComponent<GS14_Parts>();
            if (dragPart == null)
            {
                return;
            }
            if (part != dragPart)
            {
                return;
            }
            // partとeventDataの向きが同じかどうか
            if (Mathf.Abs(correctAngle - dragPart.transform.eulerAngles.z) > 10f)
            {
                return;
            }
            float diff = (transform.position -dragPart.transform.position).sqrMagnitude;
            // Debug.Log(transform.position + ":" + dragPart.transform.position + "=" + diff);
            if ((transform.position - dragPart.transform.position).sqrMagnitude > 0.3f)
            {
                return;
            }
            dragPart.isClearPos = true;
            // 0.3f秒間かけてpartをtransform.positionに移動させる
            dragPart.transform.DOMove(transform.position, 0.3f).OnComplete(
                ()=>
                {
                    CriManager.instance.PlayObjSE("ObjSet");
                    part.gameObject.SetActive(false);
                    GS14_MiniGameManager.Instance.SetNextPart();
                    gameObject.SetActive(false);
                    clearPart.SetActive(true);
                });
        }
    }
}
