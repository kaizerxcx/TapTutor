using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NotificationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button back;
    public Button exit;
    public Button restart;
    public string sceneName;
    void Start()
    {
        back.onClick.AddListener(goToHome);
        exit.onClick.AddListener(goToHome);
        restart.onClick.AddListener(restartGame);
    }
    void restartGame()
    {
        LevelController.isRestart = true;
        SceneManager.LoadScene(sceneName);

    }
    void goToHome()
    {
       // SoundManagerScript.playSound("buttonSound");
        SceneManager.LoadScene("HomeScreen");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
