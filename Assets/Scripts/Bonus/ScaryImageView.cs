using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ScaryImageView : MonoBehaviour
{
    VideoPlayer videoPlayer;

    private void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
        videoPlayer.playOnAwake = false;

        Hide();
    }

    public void Play()
    {
        videoPlayer.Play();
    }

    public void Stop()
    {
        videoPlayer.Stop();
    }

    public void Show()
    {
        videoPlayer.gameObject.SetActive(true);
    }

    public void Hide()
    {
        videoPlayer.gameObject.SetActive(false);
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        Stop();
        Hide();
    }
}
