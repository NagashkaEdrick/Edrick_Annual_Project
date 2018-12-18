using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalControler : MonoBehaviour
{

    [SerializeField]
    float maxSpeed = 1.2f;
    [SerializeField]
    float jumpForce = 200f;
    [SerializeField]
    bool bGrounded;
    Rigidbody2D rigidBody;
    bool bFacingRight = true;
    bool bKinematic = false;
    [SerializeField]
    bool bDoubleJump;

    public Transform checkGround;
    public float groundRadius = 0.2f;
    public LayerMask groundMask;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bGrounded = Physics2D.OverlapCircle(checkGround.position,groundRadius,groundMask);
        if (bGrounded)
        {
            bDoubleJump = false;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (bKinematic)
        {
            rigidBody.velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
        }

        else
        {
            rigidBody.velocity = new Vector2(moveX * maxSpeed, rigidBody.velocity.y);
        }

        if ((moveX > 0 && !bFacingRight) || (moveX < 0 && bFacingRight))
        {
            FlipSprite();
        }

    }

    private void Update()
    {

        if ((bGrounded || !bDoubleJump) && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));

            if (!bDoubleJump && !bGrounded)
            {
                bDoubleJump = true;
            }
        }   

    }
    
    private void OnTriggerExit2D(Collider2D ladder)
    {
        if (ladder.gameObject.tag == "Ladder")
        {
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
            bKinematic = false;
        }
    }

    private void OnTriggerStay2D(Collider2D ladder)
    {
        if (ladder.gameObject.tag == "Ladder")
        {
            rigidBody.bodyType = RigidbodyType2D.Kinematic;
            bKinematic = true;
        }
    }

    void FlipSprite()
    {
        bFacingRight = !bFacingRight;
        Vector3 spriteLocalScale = transform.localScale;
        spriteLocalScale.x *= -1;
        transform.localScale = spriteLocalScale;   
    }


}
