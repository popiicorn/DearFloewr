using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MovieSceneManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] RawImage rawImage;

    void Start()
    {
        rawImage.gameObject.SetActive(false);
        videoPlayer.loopPointReached += LoopPointReached;
		StartCoroutine(PlayStart());
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
		// 動画再生完了時の処理
		FadeManager.Instance.LoadScene("Title", 1f);
    }
}
