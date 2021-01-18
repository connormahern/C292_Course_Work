using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//https://www.youtube.com/watch?v=HpJMhNmpIxY

public class playerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Rigidbody2D playerBody;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        movement(horizontal);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            float jumpVelocity = 3f;
            playerBody.velocity = Vector2.up * jumpVelocity;
        }
        
    }

    private void movement(float horizontal)
    {
        playerBody.velocity = new Vector2(horizontal * speed , playerBody.velocity.y);
    }
}
