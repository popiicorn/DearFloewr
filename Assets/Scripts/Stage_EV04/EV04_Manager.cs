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
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSelbved4w05Dd9B4sfbXZ9YciiiTsDhhA0R4JhC6KYgvopMbQ/viewform?usp=sf_link");
        FadeManager.Instance.LoadScene("Stage_EV00", 1f);
    }
}
