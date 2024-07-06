using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbDetection_up : MonoBehaviour
{
    public bool isUpBrick;
    // Start is called before the first frame update
    void Start()
    {
        isUpBrick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Brick")){
            isUpBrick = true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Brick")){
            isUpBrick = false;
        }
    }
}
