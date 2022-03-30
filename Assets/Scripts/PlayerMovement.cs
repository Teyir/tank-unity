using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;
    public float walkSpeed = 2f;
    public float sprintSpeed = 8f;
    private float moveSpeed;
    private float gravity = -75f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.3f;
    public LayerMask groundMask;
    private Animator anim;

    private Vector3 velocity;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;



        if (!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Z))
        {
            Walk();
        }
        else if(Input.GetKey(KeyCode.LeftShift))
        {
            Run();
        }
        else
        {
            Idle();
        }

        controller.Move(move * moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }


        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = sprintSpeed;
        anim.SetFloat("Speed", 1 , 0.1f, Time.deltaTime);
    }
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

}
