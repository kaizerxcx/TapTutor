using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.UI;
using UnityEngine.Android;
using RestClient.Core.Models;

public class LetterVoiceControl : MonoBehaviour
{
    const string LANG_CODE = "en-US";
    [SerializeField] Text uiText = null;
    public Button mic;
    bool micActive;
    private string answer;
    private string answer1;
    public Text score;
    public Button question;
    private string[] questionImage;
    private int questionIndex;
    private string instruction = "Tap The Image to Read, Tap the Mic to Answer";
    private int lastNumber;

    [SerializeField] private UnityEngine.UI.Image image = null;

    // Start is called before the first frame update
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
        lastNumber = 3;
        mic.onClick.AddListener(startRecording);
        questionIndex = GetRandom(0, 9);
        questionImage = new string[9];
        questionImage[0] = "watermelon";
        questionImage[1] = "lemon";
        questionImage[2] = "vegetable";
        questionImage[3] = "banana";
        questionImage[4] = "eggplant";
        questionImage[5] = "lettuce";
        questionImage[6] = "mushroom";
        questionImage[7] = "raspberry";
        questionImage[8] = "tomato";
        answer = questionImage[questionIndex];
        startSpeaking(instruction);
        image.sprite = Resources.Load<Sprite>(questionImage[questionIndex]);
        question.onClick.AddListener(startQuestion);

    }
    public void startQuestion()
    {
       startSpeaking(questionImage[questionIndex]);
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
        if (result.Equals(answer) || result.Equals(answer1))
        {
            int point = LetterController.points += 5;
            score.text = point.ToString();
            int child_id = SessionManagement.Instance.getChildID();
            StartCoroutine(Main.Instance.web.setLetterPoints(child_id, System.Int32.Parse(score.text)));
            SoundManagerScript.playSound("answerCorrect");
            questionIndex = GetRandom(0, 9);
            answer = questionImage[questionIndex];
            image.sprite = Resources.Load<Sprite>(questionImage[questionIndex]);
            uiText.text = instruction;

        }
        else
            SoundManagerScript.playSound("answerWrong");

    }
    void OnFinalPartialSpeechResult(string result)
    {
        uiText.text = result;
        if (result.Equals(answer) || result.Equals(answer1))
        {
            int point = LetterController.points += 5;
            score.text = point.ToString();
            int child_id = SessionManagement.Instance.getChildID();
            StartCoroutine(Main.Instance.web.setLetterPoints(child_id, System.Int32.Parse(score.text)));
            SoundManagerScript.playSound("answerCorrect");
            questionIndex = GetRandom(0, 9);
            answer = questionImage[questionIndex];
            image.sprite = Resources.Load<Sprite>(questionImage[questionIndex]);
            uiText.text = instruction;
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

    int GetRandom(int min, int max)
    {
        int rand = Random.Range(min, max);
        while (rand == lastNumber)
            rand = Random.Range(min, max);
        lastNumber = rand;
        return rand;
    }
}
