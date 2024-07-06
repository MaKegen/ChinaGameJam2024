using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DestroyAnything : MonoBehaviour
{
    private InputActions Reset;
    private void Awake() {
        Reset = new InputActions();
        Reset.Enable();
        Reset.BrickControl.ResetAnything.performed += RestAnything;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void RestAnything(InputAction.CallbackContext context)
    {
        Destroy(gameObject);
        GameManager.Instance.SpawnTetromino();
    }
}
