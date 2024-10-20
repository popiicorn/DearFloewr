using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GS20_Video : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage rawImage;
    [SerializeField] GameObject fadeObj;
    public bool wasPlayed;

    void Start()
    {

        Debug.Log("Start");

        rawImage.gameObject.SetActive(false);
        videoPlayer.loopPointReached += LoopPointReached;
        videoPlayer.Prepare();
        // StartCoroutine(PlayStart());
    }



    IEnumerator PlayStart()
    {
        videoPlayer.Prepare();
        while (!videoPlayer.isPrepared)
            yield return null;
        Play();
    }

    public void Play()
    {
        wasPlayed = true;
        rawImage.gameObject.SetActive(true);
        videoPlayer.Play();
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        videoPlayer.Stop();
        // 動画再生完了時の処理
        rawImage.gameObject.SetActive(false);
        fadeObj.GetComponentInChildren<Image>().color = new Color(0, 0, 0, 1);
        fadeObj.SetActive(true);
    }
}
