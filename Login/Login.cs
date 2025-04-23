using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField UsernameInput;
    public InputField PasswordInput;
    public Text reminderText;
    public void OnLoginButtonClick()
    {
        string username = UsernameInput.text;
        string password = PasswordInput.text;
        if (username == "111" && password == "222")
        {
            print("登录成功。");
            SceneManager.LoadScene("MainScene");
            reminderText.text = "登陆成功";
        }
        else if (username == "" || password == "")
        {
            print("用户名或密码不能为空！");
            reminderText.text = "用户名或密码不能为空！";
        }
        else
        {
            print("用户名或密码错误！");
            reminderText.text = "用户名或密码错误！";
        }

    }
}
