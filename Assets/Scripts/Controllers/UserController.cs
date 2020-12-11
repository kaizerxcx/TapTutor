using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class UserController : MonoBehaviour
{
    public InputField firstname;

    public InputField middlename;

    public InputField lastname;

    public InputField age;

    public InputField username;

    public InputField password;

    public Button registerButton;

    public Button goToLogin;

    public GameObject loginCanvas;

    public GameObject registerCanvas;

    // Start is called before the first frame update
    void Start()
    {
        registerButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.web.registerUser(firstname.text, middlename.text, lastname.text, Int32.Parse(age.text), username.text, password.text));
            SceneManager.LoadScene("HomeScreen");
        });

        goToLogin.onClick.AddListener(() => {
            registerCanvas.SetActive(false);
            loginCanvas.SetActive(true);
        }
        );
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
