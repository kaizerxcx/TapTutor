using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readInput : MonoBehaviour
{

    public string starPoints;
    public GameObject inputField;
    public GameObject textDisplay;

    public void StorePoints()
    {
        starPoints = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Requires: " + starPoints + " Point/s";

    }
}