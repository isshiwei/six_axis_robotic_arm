using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAudioController : MonoBehaviour
{
    public AudioClip walkSound; // 走路音效
    private AudioSource audioSource;
    private bool isWalking = false; // 标记角色是否在移动

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = walkSound; // 设置音效
        audioSource.loop = true; // 设置为循环播放
    }
    // Update is called once per frame
    void Update()
    {
        // 检查WASD按键输入
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // 如果有水平或垂直移动输入
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            // 如果角色不在移动，则开始播放音效
            if (!isWalking)
            {
                isWalking = true;
                audioSource.Play();
            }
        }
        else
        {
            // 如果没有移动输入，则停止音效
            if (isWalking)
            {
                isWalking = false;
                audioSource.Stop();
            }
        }
    }
}
