using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript: MonoBehaviour
{
    public static AudioClip buttonsound, correctSound, wrongSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        buttonsound = Resources.Load<AudioClip>("buttonSound");
        correctSound = Resources.Load<AudioClip>("answerCorrect");
        wrongSound = Resources.Load<AudioClip>("answerWrong");

        DontDestroyOnLoad(transform.gameObject);
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void playSound(string filename)
    {
        switch (filename)
        {
            case "buttonSound":
                audioSrc.PlayOneShot(buttonsound);
                break;
            case "answerCorrect":
                audioSrc.PlayOneShot(correctSound);
                break;
            case "answerWrong":
                audioSrc.PlayOneShot(wrongSound);
                break;
        }
       
    }
}
