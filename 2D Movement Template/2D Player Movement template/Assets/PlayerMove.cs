using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb; //this helps us with collisions and other physics. 

    public float speed;//you can set this value in the editor and edit it quickly.

    private float vSpeed = 0;//this is the vertical speed of the player, it simulates gravity.


    void Start()
    {
        //this checks to see it the player already has a rigidBody, if it does use it, if it doesn't creat a new one.
        if (this.GetComponent<Rigidbody2D>() == null)
        {
            rb = this.gameObject.AddComponent<Rigidbody2D>();
        }
        else
        {
            rb = this.gameObject.GetComponent<Rigidbody2D>();
        }
        rb.gravityScale = 0;
    }

    void FixedUpdate()
    {
        //Choose one of the following depending on your game.

        //SideScrollMove();
        //TopDownMove(); 
    }

    void SideScrollMove()
    {
        float x = Input.GetAxisRaw("Horizontal"); //gets the value from the 'A' and 'D' keys and the right and left arrow keys, returns -1,0,1

        rb.velocity = new Vector2(x*speed, jump());

       

        float jump()
        {
            if (isGrounded()) // checks to see if the player is on the ground
            {
                vSpeed = 0;
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) //checks to see if the user is pressing the jump button 'W' or 'Space'
                {
                    vSpeed = 12; //sets the vertical speed to 12, Change this if you want to jump higher.

                }
            }
            

            vSpeed -= 29.4f * Time.deltaTime; //simulates gravity, Change this value to increase/decrease the gravity 

            return vSpeed;
         

            bool isGrounded()
            {
                int layer_mask = LayerMask.GetMask("Ground");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, (transform.localScale.y/2) + .1f, layer_mask);
                return hit;
                
            }
        }
    }

    void TopDownMove()
    {
        float x = Input.GetAxisRaw("Horizontal"); //gets the value from the 'A' and 'D' keys and the right and left arrow keys, returns -1,0,1
        float y = Input.GetAxisRaw("Vertical"); //gets the value from the 'W' and 'S' keys and the up and down arrow keys, returns -1,0,1

       rb.velocity = new Vector2(x,y).normalized * speed; //same as before, normalized makes it so that its a constant speed.

        
    }
}
