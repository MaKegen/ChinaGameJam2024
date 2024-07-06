using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDetection_down : MonoBehaviour
{
    public bool isDownBrick;
    // Start is called before the first frame update
    void Start()
    {
        isDownBrick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Brick")){
            isDownBrick = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Brick")){
            isDownBrick = false;
        }
    }
    
}
