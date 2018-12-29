using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Double_Jump_Controler : MonoBehaviour
{

    [SerializeField]
    float jumpForce = 200f;
    [SerializeField]
    bool bGrounded;
    Rigidbody2D rigidBody;
    [SerializeField]
    bool bDoubleJump;
    Animator anim;

    public Transform checkGround;
    public float groundRadius = 0.2f;
    public LayerMask groundMask;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        bGrounded = Physics2D.OverlapCircle(checkGround.position,groundRadius,groundMask);

        if (bGrounded && Input.GetAxis("Vertical") >= 0)
        {
            bDoubleJump = false;
        }

        if(bGrounded && Input.GetAxis("Vertical") < 0)
        {
            bDoubleJump = true;
        }
    }

    private void Update()
    {
        
        if (!bGrounded && !bDoubleJump && Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(new Vector2(0, jumpForce));
            bDoubleJump = true; 
        }   

    }
    
}
