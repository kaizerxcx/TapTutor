using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : User
{
    public int child_id { get; set; }
    public int age { get; set; }

    public string username { get; set; }

    public string password { get; set; }

    public int points { get; set; }

    public void registerChild(string firstname, string middlename, string lastname, int age, string username, string password )
    {
        this.firstname = firstname;
        this.middlename = middlename;
        this.lastname = lastname;
        this.age = age;
        this.username = username;
        this.password = password;
    }
}
