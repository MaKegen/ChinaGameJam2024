using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class son : father
{
    // Start is called before the first frame update
    private void Start() {
        Debug.Log(Health);
        Health += 10;
        Debug.Log(Health+"?");
    }

    // Update is called once per frame
}
