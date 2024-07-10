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
                if (x<0 || x>=WIDTH||y<0||y>=HEIGHT||grid[x,y] != null){
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
            Land();
            ClearFullRows();
            enabled = false;
            GameManager.Instance.SpawnTetromino();
        }
    }
     void Land()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.position.x);
            int y = Mathf.RoundToInt(child.position.y);

            grid[x, y] = child;

            if (y == HEIGHT - 1)
            {
                //GameOver
            }
        }
    }
    void ClearFullRows()
    {
        // check rows from top to bottom
        for (int y = HEIGHT - 1; y >= 0; y--)
        {
            // if row y is full 
            if (IsRowFull(y))
            {
                // TODO: spawn SFX here
                // destroy the full row
                DestroyRow(y);
                // decrease the rows above
                DecreaseRow(y);
            }
        }
    }

    bool IsRowFull(int y)
    {
        // check grids in a row if full
        for (int x = 0; x < WIDTH; x++)
        {
            if (grid[x, y] == null)
            {
                return false;
            }
        }

        return true;
    }

    void DestroyRow(int y)
    {
        for (int x = 0; x < WIDTH; x++)
        {
            Destroy(grid[x, y].gameObject);
            // after destroy the block set this transform null
            grid[x, y] = null;
        }
    }

    void DecreaseRow(int row)
    {
        // after clear a full row, decrease rows above
        for (int y = row; y < HEIGHT - 1; y++)
        {
            for (int x = 0; x < WIDTH; x++)
            {
                // if the row above has a block
                if (grid[x, y + 1] != null)
                {
                    // switch the transforms of this row and the row above 
                    grid[x, y] = grid[x, y + 1];
                    // it should be null because the transform was swapped
                    grid[x, y + 1] = null;
                    // move the swapped blocks down
                    grid[x, y].gameObject.transform.position += Vector3.down;
                }
            }
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
