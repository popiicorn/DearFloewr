using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class GS20_Video : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage rawImage;

    void Start()
    {
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
        rawImage.gameObject.SetActive(true);
        videoPlayer.Play();
    }

    public void LoopPointReached(VideoPlayer vp)
    {
        videoPlayer.Stop();
        // “®‰æÄ¶Š®—¹‚Ìˆ—
        rawImage.gameObject.SetActive(false);
    }
}
