using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EV04_Manager : MonoBehaviour
{
    [SerializeField] List<EV04_Button> buttons;

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
}
