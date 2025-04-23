using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ControllerTV : MonoBehaviour
{
    public GameObject myTV;
    private VideoPlayer player;
    private float volumeVar = 1.0f;

    void Start()
    {
        player = myTV.GetComponent<VideoPlayer>();
    }

    void Update()
    {
        //按空格键进行视频播放和暂停
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("按下了空格键");
            if (player.isPlaying)
            {
                player.Pause();
            }
            else
            {
                player.Play();
            }
        }
        //按上下方向键控制音量大小
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("按下了上键");
            volumeVar += 0.2f;
            if (volumeVar >= 1)
            {
                volumeVar = 1;
            }
            player.SetDirectAudioVolume(0, volumeVar);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("按下了下键");
            volumeVar -= 0.2f;
            if (volumeVar <= 0)
            {
                volumeVar = 0;
            }
            player.SetDirectAudioVolume(0, volumeVar);
        }
    }

    /// <summary>
    /// 播放
    /// </summary>
    public void PlayTVFn()
    {
        if (player.isPlaying == false)
        {
            player.Play();
        }
        else
        {
            player.Pause();
        }
    }
    /// <summary>
    /// 减少音量
    /// </summary>
    public void ReduceAudioFn()
    {
        volumeVar -= 0.2f;
        if (volumeVar <= 0)
        {
            volumeVar = 0;
        }
        player.SetDirectAudioVolume(0, volumeVar);
    }
    /// <summary>
    /// 增加音量
    /// </summary>
    public void AddAudioFn()
    {
        volumeVar += 0.2f;
        if (volumeVar >= 1)
        {
            volumeVar = 1;
        }
        player.SetDirectAudioVolume(0, volumeVar);
    }

}
