using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RestClient.Core.Models;
using System;
public class NumberController : MonoBehaviour
{
    public Button backButton;
    public static int points = 0;
    public GameObject completed;
    public Text score;
    public Button next;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "0";
        completed.SetActive(false);
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getNumberPoints(child_id, (r) => getPoints(r)));
        //score.text = NumberController.points.ToString();
        backButton.onClick.AddListener(back);
        next.onClick.AddListener(() =>
        {
            completed.SetActive(false);
            SceneManager.LoadScene("LevelNumber");
        });

    }
    public void getPoints(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");

        NumberController.points = Int32.Parse(response.Data);
    }
    public void back()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                // Insert Code Here (I.E. Load Scene, Etc)
                // OR Application.Quit();
                SceneManager.LoadScene("HomeScreen");
                return;
            }
        }

        if (int.Parse(score.text) == 25)
        {
           // completed.transform.localPosition = Vector3.zero;

            completed.SetActive(true);
            
        }
       
    }
}
