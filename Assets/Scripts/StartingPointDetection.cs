using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPointDetection : MonoBehaviour
{
    [SerializeField]private GameObject CanvasOn;
    [SerializeField]private InputActions TurnOnInput;
    // Start is called before the first frame update
    private void Awake() {
        TurnOnInput = new InputActions();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")){
            TurnOnInput.Enable();
            CanvasOn.SetActive(false);
        }
    }
}
