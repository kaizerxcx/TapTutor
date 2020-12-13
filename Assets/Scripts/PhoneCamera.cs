using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Random = UnityEngine.Random;

public class PhoneCamera : MonoBehaviour
{
	public Button CaptureButton;
	public Button backButton;
	public static int points = 0;
	private bool camAvailable;
	private WebCamTexture rearCam;
	private Texture defaultBackground;

	public RawImage background;
	public AspectRatioFitter fit;
	public bool takingPicture = false;

	public Button speak;
	public int instruct;
	private VoiceControllerCapture voiceController;
	public Text score;
	public Text objective;

	// Use this for initialization
	void Start()
	{
		points = 0;
		CaptureButton.onClick.AddListener(Capture);
		backButton.onClick.AddListener(back);

		voiceController = new VoiceControllerCapture();
		instruct = Random.Range(1, 9);
        switch (instruct)
        {
			case 1: voiceController.startSpeaking("Objective: Capture color red object.");
				objective.text = "Objective: Capture color red object.";
				break;
			case 2:
				voiceController.startSpeaking("Objective: Capture color blue object.");
				objective.text = "Objective: Capture color blue object.";
				break;
			case 3:
				voiceController.startSpeaking("Objective: Capture color green object.");
				objective.text = "Objective: Capture color green object.";
				break;
			case 4:
				voiceController.startSpeaking("Objective: Capture color yellow object.");
				objective.text = "Objective: Capture color yellow object.";
				break;
			case 5:
				voiceController.startSpeaking("Objective: Capture color purple object.");
				objective.text = "Objective: Capture color purple object.";
				break;
			case 6:
				voiceController.startSpeaking("Objective: Capture color violet object.");
				objective.text = "Objective: Capture color violet object.";
				break;
			case 7:
				voiceController.startSpeaking("Objective: Capture color gray object.");
				objective.text = "Objective: Capture color gray object.";
				break;
			case 8:
				voiceController.startSpeaking("Objective: Capture color white object.");
				objective.text = "Objective: Capture color white object.";
				break;
			case 9:
				voiceController.startSpeaking("Objective: Capture color black object.");
				objective.text = "Objective: Capture color black object.";
				break;

		}
		speak.onClick.AddListener(startSpeak);


		defaultBackground = background.texture;
		WebCamDevice[] devices = WebCamTexture.devices;

		if (devices.Length == 0)
			return;

		for (int i = 0; i < devices.Length; i++)
		{
			if (!devices[i].isFrontFacing)
			{
				rearCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
				break;
			}
		}

		if (rearCam == null)
			return;

		rearCam.Play();
		background.texture = rearCam;
		camAvailable = true;
		
	}
	public void startSpeak()
	{
		if(instruct == 1)
        {
			voiceController.startSpeaking("red");
		}
		else if(instruct == 2)
        {
			voiceController.startSpeaking("blue");
		}
		else if (instruct == 3)
		{
			voiceController.startSpeaking("green");
		}
		else if (instruct == 4)
		{
			voiceController.startSpeaking("yellow");
		}
		else if (instruct == 5)
		{
			voiceController.startSpeaking("purple");
		}
		else if (instruct == 6)
		{
			voiceController.startSpeaking("violet");
		}
		else if (instruct == 7)
		{
			voiceController.startSpeaking("gray");
		}
		else if (instruct == 8)
		{
			voiceController.startSpeaking("white");
		}
		else
		{
			voiceController.startSpeaking("black");
		}

	}
	public void back()
	{
		SceneManager.LoadScene("ColorsHomeScreen");
	}

	void Update()
	{
		if (!camAvailable)
			return;

        float ratio = (float)rearCam.width / (float)rearCam.height;
		fit.aspectRatio = ratio;
		float scaleY = rearCam.videoVerticallyMirrored ? -1f : 1f;
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f);

        int orient = -rearCam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);

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
	}



    public void CaptureScreenshot()
    {
        StartCoroutine(TakeScreenshotAndSave());
    }

    private IEnumerator TakeScreenshotAndSave()
    {
		takingPicture = true;
        yield return new WaitForEndOfFrame();

		var width = 700;
		var height = 800;
		var startX = 10;
		var startY = 450;

		Texture2D ss = new Texture2D(width,height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(startX, startY, width, height), 0, 0);
        ss.Apply();

        // Save the picture to Gallery/Photos
        string name = string.Format("{0}_Capture{1}_{2}.png", Application.productName, "{0}", System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        Debug.Log("Permission result: " + NativeGallery.SaveImageToGallery(ss, Application.productName + " Captures", name));
		takingPicture = false;
    }
    public void Capture()
    {
        CaptureScreenshot();
		points += 5;
		score.text = PhoneCamera.points.ToString();
	}


}
