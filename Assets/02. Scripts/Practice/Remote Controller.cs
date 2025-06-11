using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;
    public Button[] buttonUI;

    public VideoClip[] clips;
    private VideoPlayer videoPlayer;

    public int currClipIndex = 0;

    public bool isMute = false;

    private void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0];
    }

    private void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {
        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
        // videoScreen.GetComponent<VideoPlayer>().SetDirectAudioMute(0, isMute);
    }

    public void OnChangeChannel(bool isNext)
    {
        if (isNext)
        {
            currClipIndex++;
            if (currClipIndex > clips.Length - 1)
                currClipIndex = 0;
        }
        else
        {
            currClipIndex--;
            if (currClipIndex < 0)
                currClipIndex = clips.Length - 1;
        }        
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnNextChannel()
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1)
            currClipIndex = 0;
        
        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel()
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = 2;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
}
