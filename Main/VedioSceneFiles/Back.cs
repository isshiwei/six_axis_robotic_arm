using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    //����������
    public void Jump()
    {
        Debug.Log("�˳���������");
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
