using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Animation_Movement_Controller : MonoBehaviour
{
    InputActions PlayerInput;
    Animator animator;
    private bool IsCrouching;
    private bool IsRunning;
    private void Awake() {
        PlayerInput = new InputActions();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update

    #region enable启动控制与订阅事件、disable取消控制与取消订阅

    private void OnEnable() {
        PlayerInput.CharacterControls.Enable();
        PlayerInput.CharacterControls.Move.started += OnMove;
        PlayerInput.CharacterControls.Move.performed += OnMove;
        PlayerInput.CharacterControls.Move.canceled += OnMove;
        PlayerInput.CharacterControls.Crouch.started += OnCrouch;
        PlayerInput.CharacterControls.Crouch.performed += OnCrouch;
        PlayerInput.CharacterControls.Crouch.canceled += OnCrouch;
        PlayerInput.CharacterControls.Run.started += OnRunning;
        PlayerInput.CharacterControls.Run.performed += OnRunning;
        PlayerInput.CharacterControls.Run.canceled += OnRunning;
        
    }
    private void OnDisable() {
        PlayerInput.CharacterControls.Disable();
        PlayerInput.CharacterControls.Move.started -= OnMove;
        PlayerInput.CharacterControls.Move.performed -= OnMove;
        PlayerInput.CharacterControls.Move.canceled -= OnMove;
        PlayerInput.CharacterControls.Crouch.started -= OnCrouch;
        PlayerInput.CharacterControls.Crouch.performed -= OnCrouch;
        PlayerInput.CharacterControls.Crouch.canceled -= OnCrouch;
        PlayerInput.CharacterControls.Run.started -= OnRunning;
        PlayerInput.CharacterControls.Run.performed -= OnRunning;
        PlayerInput.CharacterControls.Run.canceled -= OnRunning;
    }
    #endregion


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IsCrouching = animator.GetBool("IsCrouching");
        IsRunning = animator.GetBool("IsRunning");
    }
    private void OnRunning(InputAction.CallbackContext context)
    {
        Debug.Log("跑"+context.ReadValueAsButton());
        if(context.started){
            animator.SetBool("IsRunning",!IsRunning);
            animator.SetBool("IsCrouching",false);
        }
    }

    private void OnCrouch(InputAction.CallbackContext context)
    {
        Debug.Log("蹲"+context.ReadValueAsButton());
        if(context.started){
            animator.SetBool("IsCrouching",!IsCrouching);
            animator.SetBool("IsRunning",false);
        }
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Debug.Log("在运动"+context.ReadValue<Vector2>());
        if(context.started|context.performed){
            animator.SetBool("IsWalking",true);
        }
        if(context.canceled){
            animator.SetBool("IsWalking",false);
            animator.SetBool("IsRunning",false);
            
        }
    }
}
