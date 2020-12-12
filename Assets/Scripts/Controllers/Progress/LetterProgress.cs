using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestClient.Core.Models;

public class LetterProgress : MonoBehaviour
{
    public ProgressBar letters;

    // Start is called before the first frame update
    void Start()
    {

        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getLetterPoints(child_id, (r) => getLetter(r)));
    }
    public void getLetter(Response response)
    {

        float value = float.Parse(response.Data) / 200;
        letters.BarValue = value * 100;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
