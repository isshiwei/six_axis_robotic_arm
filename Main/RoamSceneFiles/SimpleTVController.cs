using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SimpleTVController : MonoBehaviour
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

    //点击鼠标左键进行物体交互，控制视频的播放暂停
    private void OnMouseDown()
    {
        if (player.isPlaying)
        {
            player.Pause();
        }
        else
        {
            player.Play();
        }
    }
}
