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
    public Button level1Button;
    public Button level2Button;
    public string sceneName;
    public GameObject level1;
    public GameObject level2;
    void Start()
    {
        back.onClick.AddListener(goToHome);
        exit.onClick.AddListener(goToHome);
        restart.onClick.AddListener(restartGame);
        level1Button.onClick.AddListener(() =>
        {
            level1.SetActive(false);
            level2.SetActive(true);
        });
        level2Button.onClick.AddListener(() =>
        {
            level2.SetActive(false);
            level1.SetActive(true);
        });
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
