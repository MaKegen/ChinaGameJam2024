using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    private float a;
    [SerializeField]Transform Target;
    private Quaternion rotationAngle;
    // Start is called before the first frame update
    void Start()
    {
        rotationAngle = Target.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(a<=1){
            Debug.Log("a");
            a = a+1f;
        }
        if(a >= 2){
            Debug.Log("b");
            a = 0f;
        }
    }
}
