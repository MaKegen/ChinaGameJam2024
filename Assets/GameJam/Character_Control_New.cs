using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Character_Control_New : MonoBehaviour
{
    private InputActions PlayerInput;
    

    #region Player Move Control
    private CharacterController Player;
    private Vector2 Player_InputVector;
    private Vector3 PlayerMoveVector;
    private bool PlayerIsMoving = false;
    [SerializeField]private float PlayerSpeed;
    [SerializeField]private float GravityValue;
    private Quaternion CurrentRotation;
    private Quaternion TargetRotation;
    [SerializeField]private float RotationPerFrame = 10f;
    private Quaternion C;
    

    #endregion

    #region Player Climbing
    [SerializeField]private ClimbDetection_down DownDetection;
    [SerializeField]private ClimbDetection_up UpDetection;
    private bool Climb_Input = false;
    private bool ClimbAble;
    #endregion

    #region Camera Control
//    [SerializeField] Transform Camera;
    [SerializeField] Vector3 CameraOffset;
    [SerializeField] float CameraHeight;
    private Vector2 CameraRotation_InputVector;
    [SerializeField] float XAxisSensitivity;
    [SerializeField] float YAxisSensitivity;
    [SerializeField] float MaxRotationAngle;
    [SerializeField] float MinRotationAngle;
    private float XAxisRotation;
    private float YAxisRotation;
    private Quaternion RotationAngle;
    #endregion

    #region Animation Control
    private Animator PlayerAni;
    #endregion
    private void Awake() {
        Player = GetComponent<CharacterController>();
        PlayerAni = GetComponentInChildren<Animator>();
        PlayerInput = new InputActions();
    }
    private void OnEnable() {
        PlayerInput.Enable();
        PlayerInput.CharacterControls.Move.performed += MovePerformed;
        PlayerInput.CharacterControls.Move.canceled += MoveCanceled;
        PlayerInput.CharacterControls.ViewControl.performed += ViewControl;
        PlayerInput.CharacterControls.ViewControl.canceled += ViewControl;
        PlayerInput.CharacterControls.Climb.performed += ClimbPerformed;
        PlayerInput.CharacterControls.Climb.canceled += ClimbCanceled;
    }



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        HandleGravity();
        HandleClimb();
        HandleAnimation();
        Debug.Log("ClimbAble："+ClimbAble);
        Debug.Log("Climb_Input："+Climb_Input);
        Debug.Log("IsUpBrick:"+UpDetection.isUpBrick);
        Debug.Log("IsDwonBrick:"+DownDetection.isDownBrick);



    }



    private void LateUpdate() {
        //HandleCamera();
    }



    private void MovePerformed(InputAction.CallbackContext context)
    {
        PlayerIsMoving = true;
        Player_InputVector = context.ReadValue<Vector2>();
    }
    private void MoveCanceled(InputAction.CallbackContext context){
        PlayerIsMoving = false;
    }

    private void ViewControl(InputAction.CallbackContext context)
    {
        CameraRotation_InputVector = context.ReadValue<Vector2>();
    }
    private void ClimbPerformed(InputAction.CallbackContext context)
    {
        Climb_Input = true;
    }
    private void ClimbCanceled(InputAction.CallbackContext context)
    {
        Climb_Input = false;
    }
/*    private void HandleCamera()
    {
        XAxisRotation += CameraRotation_InputVector.y*YAxisSensitivity*(-1);
        YAxisRotation += CameraRotation_InputVector.x*XAxisSensitivity;
        XAxisRotation = Mathf.Clamp(XAxisRotation,MinRotationAngle,MaxRotationAngle);
        RotationAngle = Quaternion.Euler(XAxisRotation,YAxisRotation,0f);
        Camera.position = transform.position - RotationAngle * CameraOffset + Vector3.up*CameraHeight;
        Camera.rotation = RotationAngle;
    }
*/
    private void Move(){
        C = Quaternion.Euler(0f,YAxisRotation,0f);
        if(PlayerIsMoving){
            PlayerMoveVector = new Vector3(Player_InputVector.x,0f,Player_InputVector.y);
            Player.Move(C*PlayerMoveVector*PlayerSpeed*Time.deltaTime);
            CurrentRotation = transform.rotation;
            TargetRotation = Quaternion.LookRotation(C*PlayerMoveVector);
            transform.rotation = Quaternion.Slerp(CurrentRotation,TargetRotation,RotationPerFrame*Time.deltaTime);
        }

    }
    private void HandleGravity(){
        if(!Player.isGrounded){
            Player.Move((-1f)*Vector3.up*GravityValue*Time.deltaTime);
        }
    }
    private void HandleClimb(){
        if(DownDetection.isDownBrick&&(!UpDetection.isUpBrick)){
            ClimbAble = true;
        }
        else{
            ClimbAble = false;
        }

    }
        private void HandleAnimation()
    {
        if(PlayerIsMoving){
            PlayerAni.SetBool("isWalking",true);
        }
        else{
            PlayerAni.SetBool("isWalking",false);
        }
        if(ClimbAble&&Climb_Input){
            //玩家攀爬，先播放动画，trigger方法，transform.position
            PlayerAni.SetBool("isClimbing",true);
            //transform.position += new Vector3 (0f,1f,0.5f);
            //Debug.Log("aa");
        }
    }
}
