using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondControler : MonoBehaviour
{

    [SerializeField] //Check dans inspector mais pas touchable par d'autres classes
    float maxSpeed = 1.2f;
    [SerializeField]
    float jumpForce = 200f;
    [SerializeField]
    bool bGrounded;

    Rigidbody2D rigidBody;
    bool bFacingRight = true;
    bool bKinematic;
    [SerializeField]
    bool bDoubleJump;

    //Vérifier contacte sol
    public Transform checkGround;
    public float groundRadius = 0.2f;
    public LayerMask groundMask;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody.bodyType == RigidbodyType2D.Kinematic)
        {
            bKinematic = true;
        }
    }

    private void FixedUpdate()
    {
        bGrounded = Physics2D.OverlapCircle(checkGround.position,groundRadius,groundMask);
        //ResetdoubleJump
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
        /*
        if (bGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));

        }*/

        //DoubleJump
        if((bGrounded || !bDoubleJump) && Input.GetKeyDown(KeyCode.Space))
        {
             rigidBody.AddForce(new Vector2(0, jumpForce));

             if(!bDoubleJump && !bGrounded)
             {
                    bDoubleJump = true;
             }
        }
        

    }

    void FlipSprite()
        {
            bFacingRight = !bFacingRight;
            Vector3 spriteLocalScale = transform.localScale;
            spriteLocalScale.x *= -1;
            transform.localScale = spriteLocalScale;
        }
    //Propre controleur avec 2 fonctionnalité

}
