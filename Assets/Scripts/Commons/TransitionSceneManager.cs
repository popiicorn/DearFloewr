using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TransitionSceneManager : MonoBehaviour
{
    [SerializeField] List<EventData> transitionEvents = new List<EventData>();
    public void TransitionScene()
    {
        string sceneName = GameStageManager.Instance.GetNextStageName();
        SceneManager.LoadScene(sceneName);
        // FadeManager.Instance.LoadScene(sceneName, 1.0f);
    }

    private void Awake()
    {
        Cursor.visible = false;
    }

    public void OnTransitionAction()
    {
        StartCoroutine(PlayAnim());
    }

    IEnumerator PlayAnim()
    {
        foreach (EventData eventData in transitionEvents)
        {
            yield return eventData.Play();
        }
        Cursor.visible = true;
    }
}
