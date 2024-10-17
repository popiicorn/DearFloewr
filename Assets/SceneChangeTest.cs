using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangeTest : MonoBehaviour
{
    public void SceneChangeTest00 ()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SoundTest");
    }
    public void SceneChangeTest01()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SoundTest 1");
    }
}
