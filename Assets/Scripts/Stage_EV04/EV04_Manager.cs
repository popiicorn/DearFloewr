using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EV04_Manager : MonoBehaviour
{
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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            SceneManager.LoadScene("Stage_EV01");
        }
    }

    public void OnButtonAnke()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSelbved4w05Dd9B4sfbXZ9YciiiTsDhhA0R4JhC6KYgvopMbQ/viewform?usp=sf_link");
    }
}
