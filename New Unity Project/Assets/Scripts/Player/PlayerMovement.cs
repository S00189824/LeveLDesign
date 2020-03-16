using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    public CharacterController character;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float grounddistance = 0.4f;
    public LayerMask groundmask;
    public float jumpheight = 3f;
    public bool isgrounded;

    

    private void Update()
    {
        isgrounded = Physics.CheckSphere(groundCheck.position, grounddistance, groundmask);
        if(isgrounded && velocity.y < 0 )
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 Move = transform.right * x + transform.forward * y;
        character.Move(Move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isgrounded)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime * 2;
        character.Move(velocity * Time.deltaTime);
    }
}
