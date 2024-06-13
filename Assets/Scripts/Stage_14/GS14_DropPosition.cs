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
            // part‚ÆeventData‚ÌŒü‚«‚ª“¯‚¶‚©‚Ç‚¤‚©
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
            // 0.3f•bŠÔ‚©‚¯‚Äpart‚ðtransform.position‚ÉˆÚ“®‚³‚¹‚é
            dragPart.transform.DOMove(transform.position, 0.3f).OnComplete(
                ()=>
                {
                    part.gameObject.SetActive(false);
                    GS14_MiniGameManager.Instance.SetNextPart();
                    gameObject.SetActive(false);
                    clearPart.SetActive(true);
                });
        }
    }
}
