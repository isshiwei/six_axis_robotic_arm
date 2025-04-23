using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerController : MonoBehaviour
{
    ////
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    /// <summary>
    /// 
    /// </summary>

    CharacterController player;  //�����ɫ���������
    public new Transform camera; //�½�һ��camera�������ڷ�����Ҫʵ�ֵĵ�һ�˳����
    public float speed = 2f;			 //��ɫ�ƶ��ٶ�
    float x, y;                  //�����תx��y�����
    float g = 10f;               //����
    Vector3 playerrun;           //��������˶�������

    void Start()
    {
        player = GetComponent<CharacterController>();//��ȡ����Ľ�ɫ���������    
    }
    
    void Update()
    {
        //�ж�����Ƿ���ƽ����
        groundedPlayer = player.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // �������Ƿ�������UIԪ����
        if (Cursor.visible && EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.None; // ������굽��ͼ����
                Cursor.visible = true; //�������
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked; // ������굽��ͼ����
                Cursor.visible = false; //�������
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // ������굽��ͼ����
            Cursor.visible = true; //�������
        }
        

        //��������˶�
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            playerrun = new Vector3(_horizontal, 0, _vertical);
        }
        playerrun.y -= g * Time.deltaTime;
        player.Move(player.transform.TransformDirection(playerrun * Time.deltaTime * speed));

        //ʹ�����������������ӽǵ���ת
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0, x, 0);
        y = Mathf.Clamp(y, -45f, 45f);
        camera.eulerAngles = new Vector3(y, x, 0);

        //�����z�ᱣ�ֲ��䣬��ֹ�����б
        if (camera.localEulerAngles.z != 0)
        {
            float rotX = camera.localEulerAngles.x;
            float rotY = camera.localEulerAngles.y;
            camera.localEulerAngles = new Vector3(rotX, rotY, 0);
        }

        //��Ծ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime);
        //
    }


}