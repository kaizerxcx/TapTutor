﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class HomeScreenController : MonoBehaviour
{
    public Button shapeButton;
    public Button numberButton;
    public Button letterButton;
    public GameObject userDashboard;
    public GameObject homescreen;
    public Button toUserDashboard;
    // Start is called before the first frame update
    void Start()
    {
      //  Debug.Log(SessionManagement.Instance.getChildID());
        shapeButton.onClick.AddListener(goToShape);
        letterButton.onClick.AddListener(goToLetter);
        numberButton.onClick.AddListener(goToNumber);

        toUserDashboard.onClick.AddListener(() =>
        {
            homescreen.SetActive(false);
            userDashboard.SetActive(true);
        });
    }
    public void goToShape()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("LevelShape");
        return;
    }

    public void goToNumber()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("LevelNumber");



    }
    public void goToLetter()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("LevelLetter");


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
                Application.Quit();
                return;
            }
        }
    }
}
