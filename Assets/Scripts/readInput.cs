using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readInput : MonoBehaviour
{

  
    public InputField inputField;
    public Text textDisplay;
    public Button button;
    public void StorePoints()
    {
        string starPoints = inputField.text;
        button.onClick.AddListener(() =>
        {
            textDisplay.text = "Requires: " + starPoints + " Point/s";
        });

    }
    
}