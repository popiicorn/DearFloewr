using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameClear;
    private void Awake()
    {
        Instance = this;
    }
    public void GameClear()
    {
        if (IsGameClear)
        {
            return;
        }
        IsGameClear = true;
        StartCoroutine(ToMovieScene());
    }

    IEnumerator ToMovieScene()
    {
        yield return new WaitForSeconds(3);
        FadeManager.Instance.LoadScene("Movie", 1f);
    }
}
