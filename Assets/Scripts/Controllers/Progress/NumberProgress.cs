using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestClient.Core.Models;

public class NumberProgress : MonoBehaviour
{
    public ProgressBar numbers;

    // Start is called before the first frame update
    void Start()
    {

        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getNumberPoints(child_id, (r) => getNumber(r)));
    }
    public void getNumber(Response response)
    {

        float value = float.Parse(response.Data) / 200;
       numbers.BarValue = value * 100;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
