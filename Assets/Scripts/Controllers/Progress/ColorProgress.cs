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
        color.BarValue = 0f;
    }
    public void getColor(Response response)
    {

       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
