using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionManagement : MonoBehaviour
{
    public static SessionManagement Instance;

    public int child_id;

    public int isLogin;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setChildID(int child_id)
    {
        PlayerPrefs.SetInt("child_id", child_id);
    }

    public int getChildID()
    {
        return PlayerPrefs.GetInt("child_id");
    }

    public void setIsLogin(int value)
    {
        PlayerPrefs.SetInt("isLogin", value);
    }
    public int getIsLogin()
    {
        return PlayerPrefs.GetInt("isLogin");
    }

}
