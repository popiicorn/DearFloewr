using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieSceneManager : MonoBehaviour
{
    [SerializeField]
    VideoPlayer videoPlayer;

    void Start()
    {
        // FadeManager.Instance.gameObject.SetActive(false);
        videoPlayer.loopPointReached += LoopPointReached;
        videoPlayer.Play();

    }


    public void LoopPointReached(VideoPlayer vp)
    {
        // 動画再生完了時の処理
        FadeManager.Instance.gameObject.SetActive(true);
        FadeManager.Instance.LoadScene("Title", 1f);
    }
}
