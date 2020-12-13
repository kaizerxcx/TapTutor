using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ColorsHomeScreen : MonoBehaviour
{
    public Button pronunciationButton;
    public Button captureButton;
    public Button popButton;
    public Button slnButton;
    // Start is called before the first frame update
    void Start()
    {
        pronunciationButton.onClick.AddListener(goToPronunciation);
        captureButton.onClick.AddListener(goToCapture);
        popButton.onClick.AddListener(goToPop);
        slnButton.onClick.AddListener(goToSln);
    }
    public void goToPronunciation()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("ColorPronunciation");
        return;
    }
    public void goToCapture()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("ColorCapture");
        return;
    }
    public void goToPop()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("ColorPop");
        return;
    }
    public void goToSln()
    {
        SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("HomeScreen");
        return;
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
    }
}
