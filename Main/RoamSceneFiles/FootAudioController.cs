using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootAudioController : MonoBehaviour
{
    public AudioClip walkSound; // ��·��Ч
    private AudioSource audioSource;
    private bool isWalking = false; // ��ǽ�ɫ�Ƿ����ƶ�

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (!audioSource)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.clip = walkSound; // ������Ч
        audioSource.loop = true; // ����Ϊѭ������
    }
    // Update is called once per frame
    void Update()
    {
        // ���WASD��������
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        // �����ˮƽ��ֱ�ƶ�����
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            // �����ɫ�����ƶ�����ʼ������Ч
            if (!isWalking)
            {
                isWalking = true;
                audioSource.Play();
            }
        }
        else
        {
            // ���û���ƶ����룬��ֹͣ��Ч
            if (isWalking)
            {
                isWalking = false;
                audioSource.Stop();
            }
        }
    }
}
