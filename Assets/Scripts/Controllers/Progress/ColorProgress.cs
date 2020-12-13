using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestClient.Core.Models;

public class ColorProgress : MonoBehaviour
{
    public ProgressBar color;

    // Start is called before the first frame update
    void Start()
    {

        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getColorPoints(child_id, (r) => getColor(r)));
    }
    public void getColor(Response response)
    {
        float value = float.Parse(response.Data) / 200;
        color.BarValue = value * 100;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
