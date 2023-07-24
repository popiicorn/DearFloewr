using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrap : MonoBehaviour
{
    [SerializeField] float timeOfActive;
    [SerializeField] GameObject emotion;
    WaitForSeconds wait;
    private void Awake()
    {
        wait = new WaitForSeconds(timeOfActive);
    }
    public void Show()
    {
        StopAllCoroutines();
        StartCoroutine(ShowCor());
    }

    IEnumerator ShowCor()
    {
        emotion.SetActive(true);
        yield return wait;
        emotion.SetActive(false);
    }
}
