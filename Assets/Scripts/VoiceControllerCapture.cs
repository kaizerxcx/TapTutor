using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;
using System;
public class VoiceControllerCapture : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    [SerializeField] Text uiText =  null;
    public Button mic;
    bool micActive;
    public static string answer;
    public static string answer1;
    public Text score;
    void Start()
    {

        setUp(LANG_CODE);

#if UNITY_ANDROID
        SpeechToText.instance.onPartialResultsCallback = OnFinalPartialSpeechResult;
#endif
        SpeechToText.instance.onResultCallback = OnFinalSpeechResult;

        TextToSpeech.instance.onStartCallBack = onSpeakStart;
        TextToSpeech.instance.onDoneCallback = onSpeakStop;

        checkPermision();

        mic.onClick.AddListener(startRecording);
    }
    
    
    void startRecording()
    {
        if (micActive)
        {
            stopListening();
            micActive = false;
        }
        else
        {
            startListening();
            micActive = true;
        }
       
    }
   void checkPermision()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
#region Text To Speech
    public void startSpeaking(string message)
    {
        TextToSpeech.instance.StartSpeak(message);
    }
    public void stopSpeaking()
    {
        TextToSpeech.instance.StopSpeak();
    }
    void onSpeakStart()
    {
        Debug.Log("Talking Started");
    }
    void onSpeakStop()
    {
        Debug.Log("Talking Stopped");
    }
#endregion

#region Speech To Text
    public void startListening()
    {
        SpeechToText.instance.StartRecording();
        uiText.text = "Listening....";
    }
    public void stopListening()
    {
        SpeechToText.instance.StopRecording();
        uiText.text = "Recording Stopped.";

    }
    void OnFinalSpeechResult(string result)
    {
        uiText.text = result;
        if (result.Equals(answer)|| result.Equals(answer1))
        {
            int point = NumberController.points += 5;
            score.text = point.ToString();
            SoundManagerScript.playSound("answerCorrect");
        }
        else
            SoundManagerScript.playSound("answerWrong");

    }
    void OnFinalPartialSpeechResult(string result)
    {
            uiText.text = result;
         if (result.Equals(answer)|| result.Equals(answer1))
         {
             int point = NumberController.points += 5;
             score.text = point.ToString();
            SoundManagerScript.playSound("answerCorrect");
        }
        else
            SoundManagerScript.playSound("answerWrong");
    }
#endregion
    void setUp(string code)
    {
        TextToSpeech.instance.Setting(code, 1, 1);
        SpeechToText.instance.Setting(code);
    }
}
