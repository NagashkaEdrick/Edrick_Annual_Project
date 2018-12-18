using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator_Controler : MonoBehaviour
{

    [SerializeField]
    float maxSpeed = 1.2f;
    [SerializeField]
    float jumpForce = 200f;
    [SerializeField]
    bool bGrounded;
    bool bOnTheGround = false;
    Rigidbody2D rigidBody;
    bool bFacingRight = true;
    bool bKinematic = false;
    [SerializeField]
    bool bDoubleJump;
    Animator anim;
    float positionY;
    float lastPositionY;
    bool bFall;

    public Transform checkGround;
    public float groundRadius = 0.2f;
    public LayerMask groundMask;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        Debug.Log("Deux fonctionnalitées on été ajoutées :");
        Debug.Log("- Monter à l'échelle");
        Debug.Log("- S'accroupir en déplaceant un box collider 2D avec S par défaut");
        anim = GetComponent<Animator>();
        lastPositionY = this.gameObject.GetComponent<Transform>().position.y;
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");


        bGrounded = Physics2D.OverlapCircle(checkGround.position,groundRadius,groundMask);

        if(bGrounded == true)
        {
            anim.SetBool("Grounded", true);
        }

        else
        {
            anim.SetBool("Grounded", false);
        }

        if (bGrounded && Input.GetAxis("Vertical") >= 0)
        {
            bDoubleJump = false;
            bOnTheGround = false;
            this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(-0.001f, 0.006f);
            anim.SetBool("Is_Crouch", false);
        }

        if(bGrounded && Input.GetAxis("Vertical") < 0)
        {
            bDoubleJump = true;
            this.gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(0.09f, -0.1f);
            bOnTheGround = true;
            anim.SetBool("Is_Crouch", true);
        }


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

        positionY = this.gameObject.GetComponent<Transform>().position.y;

        if (positionY <= lastPositionY)
        {
            bFall = true;
            anim.SetTrigger("Fall");
        }

        else
        {
            bFall = false;
        }

        lastPositionY = positionY;

    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (moveX < 0)
        {
            moveX = -moveX;
        }

        if(moveY < 0)
        {
            moveY = -moveY;
        }

        anim.SetFloat("Velocity.x", moveX);
        anim.SetFloat("Velocity.y", moveY);

        if(bFall == true)
        {
            anim.SetBool("Fall", true);
        }
        else
        {
            anim.SetBool("Fall", false);
        }

        if ((bGrounded || !bDoubleJump) && Input.GetButtonDown("Jump") && !bOnTheGround)
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
            anim.SetBool("Is_Climb", false);
        }
    }

    private void OnTriggerStay2D(Collider2D ladder)
    {
        if (ladder.gameObject.tag == "Ladder")
        {
            rigidBody.bodyType = RigidbodyType2D.Kinematic;
            bKinematic = true;
            anim.SetBool("Is_Climb", true);
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
