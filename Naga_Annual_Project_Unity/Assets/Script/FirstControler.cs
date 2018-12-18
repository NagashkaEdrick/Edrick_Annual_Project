using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstControler : MonoBehaviour
{

    [SerializeField] //Check dans inspector mais pas touchable par d'autres classes
    float maxSpeed = 1.2f;

    Rigidbody2D rigidBody;
    bool bFacingRight = true;
    bool bKinematic;


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
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (bKinematic)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveX * maxSpeed, moveY * maxSpeed);
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

    void FlipSprite()
        {
            bFacingRight = !bFacingRight;
            Vector3 spriteLocalScale = transform.localScale;
            spriteLocalScale.x *= -1;
            transform.localScale = spriteLocalScale;
        }


}
