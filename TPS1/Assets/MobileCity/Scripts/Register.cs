using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Register : MonoBehaviour
{

    public InputField usernameInput;
    public InputField passwordInput;
    public Button registerButton;
    public Button goToLoginButton;

    ArrayList Account;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(writeStuffToFile);
        goToLoginButton.onClick.AddListener(goToLoginScene);

        if (File.Exists(Application.dataPath + "/Account.txt"))
        {
            Account = new ArrayList(File.ReadAllLines(Application.dataPath + "/Account.txt"));
        }
        else
        {
            File.WriteAllText(Application.dataPath + "/Account.txt", "");
        }

    }

    void goToLoginScene()
    {
        SceneManager.LoadScene("Login");
    }


    void writeStuffToFile()
    {
        bool isExists = false;

        Account = new ArrayList(File.ReadAllLines(Application.dataPath + "/Account.txt"));
        foreach (var i in Account)
        {
            if (i.ToString().Contains(usernameInput.text))
            {
                isExists = true;
                break;
            }
        }

        if (isExists)
        {
            Debug.Log($"Username '{usernameInput.text}' already exists");
        }
        else
        {
            Account.Add(usernameInput.text + ":" + passwordInput.text);
            File.WriteAllLines(Application.dataPath + "/Account.txt", (String[])Account.ToArray(typeof(string)));
            Debug.Log("Dang ky thanh cong");
        }
    }


}