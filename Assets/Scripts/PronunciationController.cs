using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RestClient.Core.Models;
using System;
public class PronunciationController : MonoBehaviour
{
    public Button backButton;
    public static int points;
    public GameObject completed;
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        completed.SetActive(false);
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getColorPoints(child_id, (r) => getPoints(r)));
        backButton.onClick.AddListener(Back);
    }
    public void getPoints(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");

        PronunciationController.points = Int32.Parse(response.Data);
    }
    public void Back()
    {
        SceneManager.LoadScene("ColorsHomeScreen");
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
                SceneManager.LoadScene("ColorsHomeScreen");
                return;
            }
        }
        if (int.Parse(score.text) == 15)
        {
            completed.transform.localPosition = Vector3.zero;
            completed.SetActive(true);

        }
    }
}
