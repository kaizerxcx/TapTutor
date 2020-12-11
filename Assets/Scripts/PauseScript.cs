using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas;
    public Button pause;
    public Button continueGame;
    public Button quit;
    void Start()
    {
        canvas.SetActive(false);
        pause.onClick.AddListener(pauseGame);
        continueGame.onClick.AddListener(continuePlaying);
       quit.onClick.AddListener(quitGame);

    }
    void pauseGame()
    {
        canvas.transform.localPosition = Vector3.zero;
        canvas.SetActive(true);
        Debug.Log("click");
    }
    void continuePlaying()
    {
        canvas.SetActive(false);
    }
    void quitGame()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
