using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionSceneManager : MonoBehaviour
{
    public void TransitionScene()
    {
        string sceneName = GameStageManager.Instance.GetNextStageName();
        SceneManager.LoadScene(sceneName);
        // FadeManager.Instance.LoadScene(sceneName, 1.0f);
    }
}
