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

    CharacterController player;  //定义角色控制器组件
    public new Transform camera; //新建一个camera对象用于放入所要实现的第一人称相机
    public float speed = 2f;			 //角色移动速度
    float x, y;                  //相机旋转x，y轴控制
    float g = 10f;               //重力
    Vector3 playerrun;           //控制玩家运动的向量

    void Start()
    {
        player = GetComponent<CharacterController>();//获取人物的角色控制器组件    
    }
    
    void Update()
    {
        //判断玩家是否在平面上
        groundedPlayer = player.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // 检查鼠标是否悬浮在UI元素上
        if (Cursor.visible && EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.None; // 锁定鼠标到视图中心
                Cursor.visible = true; //隐藏鼠标
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Cursor.lockState = CursorLockMode.Locked; // 锁定鼠标到视图中心
                Cursor.visible = false; //隐藏鼠标
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None; // 锁定鼠标到视图中心
            Cursor.visible = true; //隐藏鼠标
        }
        

        //控制玩家运动
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        if (player.isGrounded)
        {
            playerrun = new Vector3(_horizontal, 0, _vertical);
        }
        playerrun.y -= g * Time.deltaTime;
        player.Move(player.transform.TransformDirection(playerrun * Time.deltaTime * speed));

        //使用鼠标来控制相机的视角的旋转
        x += Input.GetAxis("Mouse X");
        y -= Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0, x, 0);
        y = Mathf.Clamp(y, -45f, 45f);
        camera.eulerAngles = new Vector3(y, x, 0);

        //让相机z轴保持不变，防止相机倾斜
        if (camera.localEulerAngles.z != 0)
        {
            float rotX = camera.localEulerAngles.x;
            float rotY = camera.localEulerAngles.y;
            camera.localEulerAngles = new Vector3(rotX, rotY, 0);
        }

        //跳跃
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        player.Move(playerVelocity * Time.deltaTime);
        //
    }


}