using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapDetection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() {
        EventManager.OnTrapDetected += Mess;

    }
    private void OnDisable() {
        EventManager.OnTrapDetected -= Mess;

    }

    private void Mess()
    {
        Debug.Log("aa");
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            EventManager.OnTrap();

        }
    }

}
