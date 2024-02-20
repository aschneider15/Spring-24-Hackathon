using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController cc; //this helps us with collisions and other physics. 

    public float speed;//you can set this value in the editor and edit it quickly.

    private float vSpeed = 0;//this is the vertical speed of the player, it simulates gravity.


    void Start()
    {
        //this checks to see it the player already has a character controller, if it does use it, if it doesn't creat a new one.
        if (this.GetComponent<CharacterController>() == null)
        {
            cc = this.gameObject.AddComponent<CharacterController>();
        }
        else
        {
            cc = this.gameObject.GetComponent<CharacterController>();
        }
    }

    void Update()
    {
        //Choose one of the following depending on your game.

        //SideScrollMove();
        //TopDownMove(); 
    }

    void SideScrollMove()
    {
        float x = Input.GetAxisRaw("Horizontal"); //gets the value from the 'A' and 'D' keys and the right and left arrow keys, returns -1,0,1


        Vector2 move = (transform.right * x) * speed;//applies the input value to the x-axis of the player and multiplies it by the movement speed.

        move.y = jump(); //sets the vertaical speed to the return value of the jump function.

        cc.Move(move * Time.deltaTime); //tells the Character Controller to move the correct amount every frame

        float jump()
        {
            if (cc.isGrounded) // checks to see if the player is on the ground
            {
          
                if (Input.GetKey(KeyCode.W)) //checks to see if the user is pressing the jump button 'W'
                {
                    vSpeed = 12; //sets the vertical speed to 12, Change this if you want to jump higher.

                }
            }
            

            vSpeed -= 29.4f * Time.deltaTime; //simulates gravity, Change this value to increase/decrease the gravity 

            return vSpeed;
        }
    }

    void TopDownMove()
    {
        float x = Input.GetAxisRaw("Horizontal"); //gets the value from the 'A' and 'D' keys and the right and left arrow keys, returns -1,0,1
        float y = Input.GetAxisRaw("Vertical"); //gets the value from the 'W' and 'S' keys and the up and down arrow keys, returns -1,0,1

        Vector2 move = ((transform.right * x) + (transform.up * y)).normalized * speed; //same as before, normalized makes it so that its a constant speed.

        cc.Move(move * Time.deltaTime);//tells the Character Controller to move the correct amount every frame
    }
}
