using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestClient.Core.Models;
using Newtonsoft.Json;
using System;
using UnityEngine.SceneManagement;

public class UserLeaderboard : MonoBehaviour
{
  
     public GameObject item;

    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(Main.Instance.web.getLeaderboard((r) => progressUser(r)));
        
      
    }
    public void progressUser(Response response)
    {
        int i = 1;
        Debug.Log(response.Data);
        var Sresponse = JsonConvert.DeserializeObject<List<Child>>(response.Data);
        foreach (var result in Sresponse)
        {
            if(i <= 3)
            {
          GameObject items = Instantiate<GameObject>(item, transform);
                items.transform.Find("Rank").GetComponent<Text>().text = i.ToString();
                items.transform.Find("Name").GetComponent<Text>().text = result.username;
                items.transform.Find("Score").GetComponent<Text>().text = result.points.ToString();

            }
            i++;
            Debug.Log(i);
        }
       
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }
}
