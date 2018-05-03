using UnityEngine;
using System.Collections;

public class move : MonoBehaviour
{

    private float walkSpeed;
    private float jumpSpeed;
    private float gravity;
    private Vector3 moveDirection;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        walkSpeed = 2.0F;
        jumpSpeed = 8.0F;
        gravity = 20.0F;
    }
    void Update() {
        
        if (controller.isGrounded) 
        {
            float Horizontal = Input.GetAxis("Horizontal");
            float Vertical = Input.GetAxis("Vertical");

            moveDirection = new Vector3(Horizontal, 0, Vertical);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                walkSpeed = 6.00f;            
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                walkSpeed = 2.00f;
            }
            moveDirection = transform.TransformDirection(moveDirection) * walkSpeed;
            
            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
            
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


	    
	
}
