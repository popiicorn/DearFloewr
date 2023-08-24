using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GS07_3GameManager : MonoBehaviour
{
    bool isGameOver;
    string stageName;
    private void Start()
    {
        stageName = SceneManager.GetActiveScene().name;
    }
    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        isGameOver = true;
        FadeManager.Instance.LoadScene(stageName, 1);
    }

}
