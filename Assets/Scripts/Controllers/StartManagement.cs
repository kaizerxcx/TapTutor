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
    }

    void OnRequestComplete(Response response)
    {
        /*   Debug.Log($"Status Code: {response.StatusCode}");
           Debug.Log($"Data: {response.Data}");
           Debug.Log($"Error: {response.Error}");*/
        /*
                if (response.Data.Contains("Login Success"))
                {
                    SceneManager.LoadScene("HomeScreen");
                    Debug.Log($"Data: {response.Data}");
                }
                else
                {
                    Debug.Log($"Status Code: {response.StatusCode}");
                    Debug.Log($"Data: {response.Data}");
                    Debug.Log($"Error: {response.Error}");
                }*/

        /* var Sresponse = JsonConvert.DeserializeObject<List<Child>>(response.Data);
         foreach (var result in Sresponse)
         {
             child_id = result.child_id;
         }
         if (Int32.TryParse(child_id.ToString(), out int number))
         {
             SceneManager.LoadScene("HomeScreen");
         }
         else
             Debug.Log(child_id);*/
        if (Int32.Parse(response.Data) > 0)
        {
            SceneManager.LoadScene("HomeScreen");
            SessionManagement.Instance.setIsLogin(1);
            SessionManagement.Instance.setChildID(Int32.Parse(response.Data));
         
        }
        else
        {
            SessionManagement.Instance.setIsLogin(0);
            Debug.Log(response.Data);
        }


    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
