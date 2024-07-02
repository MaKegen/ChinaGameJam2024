using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Character_Movement_Controller : MonoBehaviour
{
    InputActions PlayerInput;
    Animator animator;
    private bool IsCrouching;
    private bool IsRunning;
    private Vector2 InputDirection;
    private Vector3 MoveDirection;
    private Quaternion CurrentRotation;
    [SerializeReference]private float RotationPerFrame;
    private Vector3 RotationDestination;
    [SerializeField]private float MovementSpeed;
    [SerializeField]private float RunningSpeed;
    private CharacterController player;
    private void Awake() {
        PlayerInput = new InputActions();
        animator = GetComponentInChildren<Animator>();
        player = GetComponent<CharacterController>();
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
        if(IsRunning){
            player.Move(MoveDirection*RunningSpeed*Time.deltaTime);
        }
        else{
            player.Move(MoveDirection*Time.deltaTime);
        }
        HandleRotation();
        
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
        InputDirection = context.ReadValue<Vector2>();
        MoveDirection = new Vector3(InputDirection.x,0,InputDirection.y)*MovementSpeed;
        if(context.started|context.performed){
            animator.SetBool("IsWalking",true);
        }
        if(context.canceled){
            animator.SetBool("IsWalking",false);
            animator.SetBool("IsRunning",false);
            
        }
    }
    private void HandleRotation(){
        RotationDestination.x = InputDirection.x;
        RotationDestination.y = 0f;
        RotationDestination.z = InputDirection.y;
        CurrentRotation = transform.rotation;
        Quaternion TargetRotation = Quaternion.LookRotation(RotationDestination);
        transform.rotation = Quaternion.Slerp(CurrentRotation,TargetRotation,RotationPerFrame*Time.deltaTime);
    }
}
