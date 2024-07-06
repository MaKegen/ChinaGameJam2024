using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class BrickMovement : MonoBehaviour
{
    static Transform[,] grid = new Transform[WIDTH, HEIGHT];
    
    private InputActions BrickInput;
    const int WIDTH = 12;
    const int HEIGHT = 22;
    
    bool Moveable{
        get{
            foreach(Transform child in transform){
                int x = (int)child.position.x;
                int y = (int)child.position.y;
                if (x<0 || x>=WIDTH||y<=0||y>=HEIGHT||grid[x,y] != null){
                    return false;
                }
                
            }
            return true;
        }
    }
    private void Awake() {
        BrickInput = new InputActions();
    }
    // Start is called before the first frame update
    private void OnEnable() {
        BrickInput.Enable();
        BrickInput.BrickControl.BrickLeft.performed += BrickMoveLeft;
        BrickInput.BrickControl.BrickRight.performed += BrickMoveRight;
        BrickInput.BrickControl.BrickDrop.performed += BrickMoveDrop;
        BrickInput.BrickControl.BrickRotate.performed += BrickMoveRotate;

    }



    private void OnDisable() {
        BrickInput.Disable();
        BrickInput.BrickControl.BrickLeft.performed -= BrickMoveLeft;
        BrickInput.BrickControl.BrickRight.performed -= BrickMoveRight;
        BrickInput.BrickControl.BrickDrop.performed -= BrickMoveDrop;
        BrickInput.BrickControl.BrickRotate.performed -= BrickMoveRotate;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


        private void BrickMoveRotate(InputAction.CallbackContext context)
    {
        transform.Rotate(Vector3.forward,90f);
        if(!Moveable){
            transform.Rotate(Vector3.forward,-90f);
        }
    }
        private void BrickMoveDrop(InputAction.CallbackContext context)
    {
        transform.position += Vector3.down;
        if(!Moveable){
            transform.position += Vector3.up;
        }
    }

    private void BrickMoveRight(InputAction.CallbackContext context)
    {
        transform.position += (-1f)*Vector3.left;
        if(!Moveable){
            transform.position += Vector3.left;
        }
    }

    private void BrickMoveLeft(InputAction.CallbackContext context)
    {
        transform.position += Vector3.left;
        if(!Moveable){
            transform.position += (-1f)*Vector3.left;
        }
    }


}
