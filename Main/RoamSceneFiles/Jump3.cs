using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump3 : MonoBehaviour
{
    //�������ν���
    public void Jump()
    {
        Debug.Log("�������ν���");
        SceneManager.LoadScene("RoamScene");
    }
}
