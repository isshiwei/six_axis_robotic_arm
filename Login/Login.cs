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
            print("��¼�ɹ���");
            SceneManager.LoadScene("MainScene");
            reminderText.text = "��½�ɹ�";
        }
        else if (username == "" || password == "")
        {
            print("�û��������벻��Ϊ�գ�");
            reminderText.text = "�û��������벻��Ϊ�գ�";
        }
        else
        {
            print("�û������������");
            reminderText.text = "�û������������";
        }

    }
}
