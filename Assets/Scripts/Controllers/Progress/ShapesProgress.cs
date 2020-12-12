using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RestClient.Core.Models;

public class ShapesProgress : MonoBehaviour
{
    public ProgressBar shapes;

    // Start is called before the first frame update
    void Start()
    {
       
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getShapePoints(child_id, (r) => getShape(r)));
    }
    public void getShape(Response response)
    {

        float value = float.Parse(response.Data) / 200;
        shapes.BarValue = value * 100;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
