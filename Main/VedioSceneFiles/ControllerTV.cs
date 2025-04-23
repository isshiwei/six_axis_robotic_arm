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
        //���ո��������Ƶ���ź���ͣ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("�����˿ո��");
            if (player.isPlaying)
            {
                player.Pause();
            }
            else
            {
                player.Play();
            }
        }
        //�����·��������������С
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("�������ϼ�");
            volumeVar += 0.2f;
            if (volumeVar >= 1)
            {
                volumeVar = 1;
            }
            player.SetDirectAudioVolume(0, volumeVar);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("�������¼�");
            volumeVar -= 0.2f;
            if (volumeVar <= 0)
            {
                volumeVar = 0;
            }
            player.SetDirectAudioVolume(0, volumeVar);
        }
    }

    /// <summary>
    /// ����
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
    /// ��������
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
    /// ��������
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
