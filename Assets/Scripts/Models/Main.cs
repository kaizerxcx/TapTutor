using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public static Main Instance;

    public Child child;

    public Web web;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
      //  child = GetComponent<Child>();
        web = GetComponent<Web>();
    }
}
