using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
public class GS14_DropPosition : MonoBehaviour, IDropHandler
{
    [SerializeField] GS14_Parts part;
    [SerializeField] float correctAngle = 0f;
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            GS14_Parts dragPart = eventData.pointerDrag.GetComponent<GS14_Parts>();
            if (dragPart == null)
            {
                return;
            }
            Debug.Log("OnDrop2");
            if (part != dragPart)
            {
                return;
            }
            // part‚ÆeventData‚ÌŒü‚«‚ª“¯‚¶‚©‚Ç‚¤‚©
            if (Mathf.Abs(correctAngle - dragPart.transform.eulerAngles.z) > 10f)
            {
                return;
            }
            
            part.gameObject.SetActive(false);
            GS14_MiniGameManager.Instance.SetNextPart();
            gameObject.SetActive(false);
        }
    }
}
