using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EV04_Manager : MonoBehaviour
{
    bool onReset;
    [SerializeField] List<EV04_Button> buttons;

    private void Start()
    {
        EventSaveDatas.Instance.StopwatchStop();
    }

    public void OnOKButton()
    {
        // データ収集
        foreach (var button in buttons)
        {
            Debug.Log(button.IsOn);
        }
    }

    public void OnButtonAnke()
    {
        if (onReset)
        {
            return;
        }
        onReset = true;
        Application.OpenURL("https://docs.google.com/forms/d/1bbIi2C-MqYD-OOJJKhKieHW0-hkYN2ro1A3yQVZMLdo/edit");
        FadeManager.Instance.LoadScene("Stage_EV00", 1f);
    }
}
