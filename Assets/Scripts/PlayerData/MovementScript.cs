using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{

    public float Speed = 0.0f;
    private float halfSpeed = 0.0f;
    public Vector2 JumpHeight = new Vector2(0f, 0f);

    private Rigidbody2D rb2d;
    private float moveHorizontal = 0.0f;

    private float moveVertical = 0.0f;
    private Animator GetAnimator;
    private bool bShouldFlip = false;
    [SerializeField]
    private bool bCanJump = false;
    [SerializeField]
    private bool bCanMorph = false;
    [SerializeField]
    private bool bIsJumping = false;
    [SerializeField]
    private bool bIsOnGround = false;
    [SerializeField]
    private bool bIsCrouching = false;
    [SerializeField]
    private int MaxJumpCount = 1;
    [SerializeField]
    private int CurrentJumpCount = 0;
    private GroundTriggerCheckScript GroundTriggerCheck;
    private ProjSpawnPointScript ProjSpawn;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        ProjSpawn = GetComponentInChildren<ProjSpawnPointScript>();
        GetAnimator = GetComponent<Animator>();
        GroundTriggerCheck = GetComponent<GroundTriggerCheckScript>();
    }


    // Start is called before the first frame update
    void Start()
    {

        CurrentJumpCount = 0;
        
        CheckMovement();
        halfSpeed = Speed / 2f;
       
    }


    private void FixedUpdate()
    {
        bIsOnGround = GroundTriggerCheck.bIsOnGround;
        // bIsCrouching = !bIsCrouching;
        GetAnimator.SetBool("IsOnGround?", bIsOnGround);
        GetAnimator.SetBool("IsInAir?", !bIsOnGround);
        GetAnimator.SetBool("IsJumping?", bIsJumping);
        GetAnimator.SetBool("IsCrouching?", bIsCrouching);

        CheckJumpState();
        CheckMovement();


        //Store the current horizontal input in the float moveHorizontal.
        moveHorizontal = Input.GetAxis("Horizontal");



        //Store the current vertical input in the float moveVertical.
        moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(new Vector2(moveHorizontal, 0) * Speed);

        if (Input.GetButtonDown("Crouch"))
        {

            bIsCrouching = !bIsCrouching;
            if (bIsCrouching)
            {
                if (!bCanMorph)
                {
                    bCanMorph = true;
                }
                else
                {
                    bCanMorph = false;
                }
            }


        }
        if (Input.GetButtonDown("Crouch") && bIsCrouching)
        {
            if (bCanMorph)
            {
                GetAnimator.SetBool("IsInAltForm?", bIsCrouching);
            }

        }

        if (Input.GetButtonDown("MoveUp"))
        {

            bIsCrouching = false;


        }

        if (Input.GetButtonDown("MoveUp") && !bIsCrouching)
        {
            GetAnimator.SetBool("IsInAltForm?", false);

        }



        if (bIsJumping)
        {
            PlayerJump();
        }

        if (moveHorizontal > 0 && !bShouldFlip)
        {
            PlayerFlip();
        }
        else if (moveHorizontal < 0 && bShouldFlip)
        {
            PlayerFlip();
        }
    }

    void CheckJumpState()
    {
        if (CurrentJumpCount < MaxJumpCount && bIsOnGround)
        {
            bCanJump = true;
        }
        else
        {
            bCanJump = false;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (bCanJump)
            {
                PlayerJump();

                //lastGroundV2 = transform.position;
            }

        }
        if (Input.GetButtonUp("Jump"))
        {
            //CurrentJumpCount = 0;
            StopJump();
        }
    }

    void PlayerJump()
    {
        if (bCanJump)
        {
            bIsJumping = true;
            CurrentJumpCount++;
            GetAnimator.SetBool("IsJumping?", bIsJumping);
            rb2d.AddForce(JumpHeight * halfSpeed);
        }
        else
        {
            StopJump();
        }
    }

    void StopJump()
    {
        if (bIsJumping)
        {
            bIsJumping = false;

        }
        if (CurrentJumpCount >= MaxJumpCount)
        {
            bIsJumping = false;
            bCanJump = false;
        }
    }

    void CheckMovement()
    {
        GetAnimator.SetFloat("AnimSpeed", moveHorizontal);
        if (moveHorizontal != 0 || moveVertical != 0)
        {
            GetAnimator.SetBool("IsIdle?", false);
        }

        else
        {
            GetAnimator.SetBool("IsIdle?", true);
        }

        if (GetAnimator.GetBool("IsOnGround?") == true)
        {
            CurrentJumpCount = 0;
        }



    }

    void PlayerFlip()
    {
        bShouldFlip = !bShouldFlip;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
