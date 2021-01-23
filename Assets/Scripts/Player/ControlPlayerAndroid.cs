using DTO;
using Invector.vCharacterController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPlayerAndroid : MonoBehaviour
{
    //[Header("Controller Input")]
    //public string horizontalInput = "Horizontal";
    //public string verticallInput = "Vertical";
    //public KeyCode jumpInput = KeyCode.Space;
    //public KeyCode strafeInput = KeyCode.Tab;
    //public KeyCode sprintInput = KeyCode.LeftShift;

    //[Header("Camera Input")]
    //public string rotateCameraXInput = "Mouse X";
    //public string rotateCameraYInput = "Mouse Y";

    public PlayerLogic playerLogic;
    public Control control;
    public Menu menu;

    public bl_Joystick stickleft; // walk
    public bl_Joystick stickright; // view

    public vThirdPersonController cc;
    public vThirdPersonCamera tpCamera;
    public Camera cameraMain;

    private void Start()
    {
        if (Application.platform != RuntimePlatform.Android)
        {
            this.gameObject.SetActive(false);
        }

        InitilizeController();
        InitializeTpCamera();
    }

    protected virtual void FixedUpdate()
    {
        cc.UpdateMotor();               // updates the ThirdPersonMotor methods
        cc.ControlLocomotionType();     // handle the controller locomotion type and movespeed
        cc.ControlRotationType();       // handle the controller rotation type
    }

    protected virtual void Update()
    {
        InputHandle();                  // update the input methods
        cc.UpdateAnimator();            // updates the Animator Parameters
    }

    public virtual void OnAnimatorMove()
    {
        cc.ControlAnimatorRootMotion(); // handle root motion animations 
    }

    protected virtual void InitilizeController()
    {
        //cc = playerLogic.GetComponent<vThirdPersonController>();

        if (cc != null)
            cc.Init();
    }

    protected virtual void InitializeTpCamera()
    {
        if (tpCamera == null)
        {
            tpCamera = FindObjectOfType<vThirdPersonCamera>();
            if (tpCamera == null)
                return;
            if (tpCamera)
            {
                tpCamera.SetMainTarget(this.transform);
                tpCamera.Init();
            }
        }
    }

    protected virtual void InputHandle()
    {
        MoveInput();
        CameraInput();
        //SprintInput();
        //StrafeInput();
        //JumpInput();
    }

    public virtual void MoveInput()
    {
        cc.input.x = stickleft.Horizontal;
        cc.input.z = stickleft.Vertical;
    }

    protected virtual void CameraInput()
    {
        if (!cameraMain)
        {
            if (!Camera.main) Debug.Log("Missing a Camera with the tag MainCamera, please add one.");
            else
            {
                cameraMain = Camera.main;
                cc.rotateTarget = cameraMain.transform;
            }
        }

        if (cameraMain)
        {
            cc.UpdateMoveDirection(cameraMain.transform);
        }

        if (tpCamera == null)
            return;

        var Y = stickright.Vertical * 0.17f;
        var X = stickright.Horizontal * 0.17f;

        tpCamera.RotateCamera(X, Y);
    }

    //protected virtual void StrafeInput()
    //{
    //    if (Input.GetKeyDown(strafeInput))
    //        cc.Strafe();
    //}

    //protected virtual void SprintInput()
    //{
    //    if (Input.GetKeyDown(sprintInput))
    //        cc.Sprint(true);
    //    else if (Input.GetKeyUp(sprintInput))
    //        cc.Sprint(false);
    //}

    /// <summary>
    /// Conditions to trigger the Jump animation & behavior
    /// </summary>
    /// <returns></returns>
    protected virtual bool JumpConditions()
    {
        return cc.isGrounded && cc.GroundAngle() < cc.slopeLimit && !cc.isJumping && !cc.stopMove;
    }

    public void ButtonJump_Click()
    {
        if ( JumpConditions())
            cc.Jump();
    }

    public void ButtonUse_Click()
    {
        playerLogic.ToUse();
    }

    public void ButtonMenu_Click()
    {
        menu.Active();
    }

    public void ButtonItem_Click()
    {
        playerLogic.OpenItem();
    }

}