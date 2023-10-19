using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_EV00 : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //クリック→新変更
            CriManager.instance.StopBGI();
            CriManager.instance.PlayObjSE("startUI");
            FadeManager.Instance.LoadScene("Stage_EV01", 2f);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                EventSaveDatas.Instance.StopwatchStart(false);
            }
            else
            {
                EventSaveDatas.Instance.StopwatchStart(true);
            }

        }
    }
}
