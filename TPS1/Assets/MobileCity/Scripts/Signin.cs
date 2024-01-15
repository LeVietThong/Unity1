using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Sigin : MonoBehaviour
{
    public InputField Inputname;
    public InputField Inputpass;
    public Button btnLogin;
    public Button signupButton;
    public GameObject popupLoading;

    private void Start()
    {
        btnLogin.onClick.AddListener(OnSigninButtonClick);
        signupButton.onClick.AddListener(OnSignupButtonClick);
    }

    private void OnSigninButtonClick()
    {
        string username = Inputname.text;
        string password = Inputpass.text;

        string filePath = "Assets/Resources/Account.txt";
        string[] accounts = File.ReadAllLines(filePath);

        foreach (string account in accounts)
        {
            string[] accountData = account.Split(',');
            if (accountData[0] == username && accountData[1] == password)
            {
                // Hiển thị Popup Loading
                popupLoading.SetActive(true);
                return;
            }
        }

        // Xử lý khi tài khoản hoặc mật khẩu không chính xác
        Debug.Log("Tài khoản hoặc mật khẩu không chính xác");
    }

    private void OnSignupButtonClick()
    {
        string username = Inputname.text;
        string password = Inputpass.text;
        

        if (username.Length > 5 && password.Length > 6 )
        {
            string filePath = "Assets/Resources/Account.txt";
            string accountData = username + "," + password ;
            File.AppendAllText(filePath, accountData + "\n");

            Debug.Log("Tài khoản đã được đăng ký thành công");
        }
        else
        {
            //Đây là phần tiếp theo của script "SigninManager":
//```csharp
            // Xử lý khi không đáp ứng các điều kiện đăng ký
            Debug.Log("Vui lòng kiểm tra lại các điều kiện đăng ký");
        }
    }
}
