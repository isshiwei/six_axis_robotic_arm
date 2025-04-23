using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    //返回主界面
    public void Jump()
    {
        Debug.Log("退出到主界面");
        SceneManager.LoadScene("MainScene");
    }
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        SceneManager.LoadScene("MainScene");
    //    }
    //}
}
