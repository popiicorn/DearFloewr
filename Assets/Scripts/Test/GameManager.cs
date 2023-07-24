using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] string nextSceneName;
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
        StartCoroutine(ToNextScene());
    }

    IEnumerator ToNextScene()
    {
        yield return new WaitForSeconds(3);
        FadeManager.Instance.LoadScene(nextSceneName, 1f);
    }
}
