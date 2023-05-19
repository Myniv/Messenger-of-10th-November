using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Reference_PlayerMovement : MonoBehaviour
// , IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] Reference_CharacterController2D controller;
    [SerializeField] Animator animator;
    [SerializeField] float runSpeed = 40f;
    [SerializeField] Button buttonRight;

    public float  horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;
    [SerializeField] bool buttonPressedRight;
    [SerializeField] bool buttonPressedLeft;
    [SerializeField] bool buttonPressedJump;
    [SerializeField] bool buttonPressedCrouch;



    // public float HorizontalMove { get => horizontalMove;}
    // public bool Jump { get => jump;}
    // public bool Crouch { get => crouch;}

    private void Start() {
        buttonPressedRight=false;
        buttonPressedLeft=false;
    }
    void Update()
    {
        // if(buttonRight){
        //     RunRight();
        // } else if(buttonPressedLeft){
        //     RunLeft();
        // }
        // if(buttonPressedJump){
        //     JumpUp();
        // }
        // if(buttonPressedCrouch){
        //     CrouchDown();
        // }
        Vector3 direction = Vector3.zero;
        Movement();

        //With different Axis Raw
        if(Input.GetKey("d") || Input.GetKey("right")){
            horizontalMove = Input.GetAxisRaw("Right")*runSpeed;
        }else if(Input.GetKeyUp("d") || Input.GetKeyUp("right")){
            horizontalMove=0*runSpeed;
        }
        if(Input.GetKey("a") || Input.GetKey("left")){
            horizontalMove = Input.GetAxisRaw("Left")*runSpeed;
        }else if(Input.GetKeyUp("a") || Input.GetKeyUp("left")){
            horizontalMove=0*runSpeed;
        }

        //With horizontal Axis Raw
        // horizontalMove = Input.GetAxisRaw("Horizontal")*runSpeed;
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump")){
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if(Input.GetButtonDown("Crouch")){
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")){
            crouch = false;
        }
    }

    public void pointerDownRight(){
        buttonPressedRight=true;
    }
    public void pointerUpRight(){
        buttonPressedRight=false;

    }
    public void pointerDownLeft(){
        buttonPressedLeft=true;

    }
    public void pointerUpLeft(){
        buttonPressedLeft=false;

    }

    public void Movement(){
        if(buttonPressedRight){
        horizontalMove = Input.GetAxisRaw("Right")*runSpeed;
        } else if(buttonPressedLeft){
        horizontalMove = Input.GetAxisRaw("Left")*runSpeed;
        } else{
            horizontalMove = 0;
        }
    }
 
    // public void OnPointerDown(PointerEventData eventData){
    //     buttonPressedRight = true;
    //     buttonPressedLeft = true;
    //     buttonPressedJump = true;
    //     buttonPressedCrouch = true;        
    // }
 
    // public void OnPointerUp(PointerEventData eventData){
    //     buttonPressedRight = false;
    //     buttonPressedLeft = false;
    //     buttonPressedJump = false;
    //     buttonPressedCrouch = false;
    // }

    // public void RunRight(){
    //     Vector3 direction = Vector3.zero;
    //     horizontalMove = Input.GetAxisRaw("Right")*runSpeed;

    //     animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
    //     Debug.Log("Right");
    // }

    // public void RunLeft(){
    //     Vector3 direction = Vector3.zero;
    //     horizontalMove = Input.GetAxisRaw("Left")*runSpeed;

    //     animator.SetFloat("Speed",Mathf.Abs(horizontalMove));
    //     Debug.Log("Left");
    // }

    // public void JumpUp(){
    //     if(Input.GetButtonDown("Jump")){
    //         jump = true;
    //         animator.SetBool("IsJumping", true);
    //     }
    //     Debug.Log("Jump");
    // }

    // public void CrouchDown(){
    //     if(Input.GetButtonDown("Crouch")){
    //         crouch = true;
    //     } else if (Input.GetButtonUp("Crouch")){
    //         crouch = false;
    //     }
    //     Debug.Log("Crouch");
    // }



    public void OnCrouching (bool isCrouching){
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate() {
        //Move Our Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
