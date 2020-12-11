using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProfileData
{
    public int starPoints;
    public int countWords;
    public int rewards;
    public int analytics;



}




public class UIscript : MonoBehaviour
{

   public void Analytics()
    {
        SceneManager.LoadScene("analytics");
    }
    public void backbtn()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    public void ytVideo()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=XqZsoesa55w");
    }
    public void ytVideo2()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=7GjOOyBoELw");
    }
    public void ytVideo3()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=HJPYDUUOWo8");
    }
    public void analyticslink()
    {
        Application.OpenURL("https://analytics.cloud.unity3d.com/data_explorer/3c1ce210-88c2-45de-a9c4-a6ab279bfaf8/?reportId=dau-mau-newusers");
    }
    public void logoutbtn()
    {
        SceneManager.LoadScene("HomeScreen");
    }
    public void Userbtn()
    {
        SceneManager.LoadScene("UserProfile");
    }
}
