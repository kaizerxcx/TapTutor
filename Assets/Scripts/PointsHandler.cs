using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestClient.Core.Models;
using System;
public class PointsHandler : MonoBehaviour
{
    public static PointsHandler Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getShapePoints(child_id, (r) => setShapes(r)));
        StartCoroutine(Main.Instance.web.getNumberPoints(child_id, (r) => setNumber(r)));
        StartCoroutine(Main.Instance.web.getLetterPoints(child_id, (r) => setLetter(r)));
    }
    public void setColor(Response response)
    {

    }

    public void setShapes(Response response)
    {
        PlayerPrefs.SetInt("shapes", Int32.Parse(response.Data));
    }
    public void setNumber(Response response)
    {
        PlayerPrefs.SetInt("number", Int32.Parse(response.Data));
    }

    public void setLetter(Response response)
    {
        PlayerPrefs.SetInt("letter", Int32.Parse(response.Data));
    }

    public int getShapes()
    {
        return PlayerPrefs.GetInt("shapes");
    }
    public int getNumber()
    {
        return PlayerPrefs.GetInt("number");
    }

    public int getLetter()
    {
        return PlayerPrefs.GetInt("letter");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
