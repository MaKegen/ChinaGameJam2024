using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class father: MonoBehaviour
{
    public int Health{get;set;} = 100;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("father被启动了，它不应该被启动");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Health);
    }
}
