using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackButtonHandler : MonoBehaviour
{
    public Button back;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
       // back.onClick.AddListener(goBack);
    }
    public void goBack()
    {
        SceneManager.LoadScene(sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
