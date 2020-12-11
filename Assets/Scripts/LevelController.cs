using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RestClient.Core.Models;
using System;
public class LevelController : MonoBehaviour
{
    public Button backButton1;
    public Button backButton2;
    public static int points = 0;
    public GameObject completed1;
    public GameObject completed2;
    public static bool isRestart;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        completed1.SetActive(false);
      
        backButton1.onClick.AddListener(back);
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getShapePoints(child_id, (r) => getPoints(r)));
   //     score.text = LetterController.points.ToString();
        LevelController.isRestart = true;

        backButton2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("HomeScreen");
        });
    }
    public void getPoints(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");

        LevelController.points = Int32.Parse(response.Data);
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

     

        if (isRestart)
        {
            completed1.SetActive(false);
            
            LevelController.isRestart = true;

        }
        if (int.Parse(score.text) == 15)
        {
            completed1.transform.localPosition = Vector3.zero;
            completed1.SetActive(true);

        }
        if (int.Parse(score.text) == 30)
        {
            completed2.SetActive(true);

        }
    }
  
}
