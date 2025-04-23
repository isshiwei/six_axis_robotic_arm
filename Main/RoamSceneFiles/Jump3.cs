using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump3 : MonoBehaviour
{
    //进入漫游界面
    public void Jump()
    {
        Debug.Log("进入漫游界面");
        SceneManager.LoadScene("RoamScene");
    }
}
