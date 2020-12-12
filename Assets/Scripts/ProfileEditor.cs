using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RestClient.Core.Models;
using Newtonsoft.Json;
using System;
public class ProfileEditor : MonoBehaviour
{
    public Text header;
    public InputField firstname;
    public InputField middlename;
    public InputField lastname;
    public InputField age;
    public InputField username;
    public InputField password;
    public Button updateButton;
    public Button deleteButton;
    // Start is called before the first frame update
    void Start()
    { 
        int child_id = SessionManagement.Instance.getChildID();
        StartCoroutine(Main.Instance.web.getUserInfo(19, (r) => getUser(r)));
        updateButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.web.editProfile(firstname.text, middlename.text, lastname.text, Int32.Parse(age.text),username.text, password.text, child_id , (r) => updateUser(r)));
        });
        
    }
    public void getUser(Response response)
    {
        Debug.Log(response.Data);
        var Sresponse = JsonConvert.DeserializeObject<List<Child>>(response.Data);
        foreach (var result in Sresponse)
        {
            header.text = result.firstname + "'s Personal Information";
            firstname.text = result.firstname;
            middlename.text = result.middlename;
            lastname.text = result.lastname;
            age.text = result.age.ToString();
            username.text = result.username;
        }
    }
    public void updateUser(Response response)
    {
        Debug.Log($"Status Code: {response.StatusCode}");
        Debug.Log($"Data: {response.Data}");
        Debug.Log($"Error: {response.Error}");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
