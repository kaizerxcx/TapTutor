using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestClient.Core.Models;
using System;
using UnityEngine.SceneManagement;

public class HomeHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject userDashboard;
    public GameObject userProfile;
    public Text letters;
    public Text numbers;
    void Start()
    {
        int child_id = SessionManagement.Instance.getChildID();
        Debug.Log(child_id);
        StartCoroutine(Main.Instance.web.getLetterPoints(child_id, (r) => getLetterPoints(r)));
        StartCoroutine(Main.Instance.web.getNumberPoints(child_id, (r) => getNumberPoints(r)));
    }
    public void getLetterPoints(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");

       letters.text = "Letters Scores: "+ Int32.Parse(response.Data);
    }
    public void getNumberPoints(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");

        numbers.text = "Numbers Scores: " + Int32.Parse(response.Data);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void goToprofile()
    {
        userDashboard.SetActive(false);
        userProfile.SetActive(true);
    }

    public void logout()
    {
        SessionManagement.Instance.setIsLogin(0);
        SceneManager.LoadScene("LandingPage");
      
    }
}
