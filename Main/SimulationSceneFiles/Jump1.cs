using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jump1 : MonoBehaviour
{
    public void Jump()
    {
        SceneManager.LoadScene("SimulationScene");
    }
}
