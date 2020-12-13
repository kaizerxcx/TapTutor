using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestClient.Core.Models;
using UnityEngine.SceneManagement;
using Newtonsoft.Json;
using System;
public class StartManagement : MonoBehaviour
{
    public GameObject registrationCanvas;

    public GameObject loginCanvas;

    public Button goToRegistration;

    public Button loginButton;

    public InputField username;

    public InputField password;

    public GameObject dialogBox;

    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        if(SessionManagement.Instance.getIsLogin() == 1)
        {
            SceneManager.LoadScene("HomeScreen");
        }
        
        goToRegistration.onClick.AddListener(() =>
        {
            loginCanvas.SetActive(false);
            registrationCanvas.SetActive(true);
        });
        loginButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.web.login(username.text, password.text, (r) => OnRequestComplete(r)));

        });

        exit.onClick.AddListener(() =>
        {
            dialogBox.SetActive(false);
        });
    }

    void OnRequestComplete(Response response)
    {
        if (Int32.Parse(response.Data) > 0)
        {
            dialogBox.SetActive(false);
            SessionManagement.Instance.setIsLogin(1);
            SessionManagement.Instance.setChildID(Int32.Parse(response.Data));
            SceneManager.LoadScene("HomeScreen");
         
        }
        else
        {
            dialogBox.SetActive(true);
            SessionManagement.Instance.setIsLogin(0);
            Debug.Log(response.Data);
        }


    }

   
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
