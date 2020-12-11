using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.GUIUtility;

public class playerpoints : MonoBehaviour
{

    public Text scoreText;
    private InputField nameText;

    public System.Random random = new System.Random();

    public int playerScore;
    public string playerName;

    public InputField NumPoints { get => nameText; set => nameText = value; }


    void start()
    {
        playerScore = random.Next(0,
                                  101);
        scoreText.text = "Score: " + playerName;
    }

    public void onAdd()
    {
        playerName = nameText.text;
    }




}
