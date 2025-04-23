using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public void Jump()
    {
        print("退出到登录界面");
        SceneManager.LoadScene("LoginScene");
    }
}
