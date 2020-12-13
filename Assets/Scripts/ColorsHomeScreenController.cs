using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ColorsHomeScreenController : MonoBehaviour
{
    public Button pronunciationButton;          //color pronunciation scene jump btn
    public Button captureButton;                //capture color scene jump btn
    public Button popButton;                    //color pop scene jump btn
    public Button slnButton;                    //shapes,letters, and numbers homescreen scene jump btn

    // Start is called before the first frame update
    void Start()
    {
        pronunciationButton.onClick.AddListener(goToPronunciation);
        captureButton.onClick.AddListener(goToCapture);
        popButton.onClick.AddListener(goToPop);
        slnButton.onClick.AddListener(goToHomeScreen);
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
    public void goToHomeScreen()
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
                Application.Quit();
                return;
            }
        }
    }
}
