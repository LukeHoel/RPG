using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.

    public Sprite idleForward;
    public Sprite idleSide;

    public Sprite walkForward1;
    public Sprite walkForward2;

    public Sprite walkSide1;
    public Sprite walkSide2;

    public int stepSpeed = 15;

    private Rigidbody2D rigidbody;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private SpriteRenderer renderer;
    private int walkNum = 0;
    private int walkChangeCounter = 0;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rigidbody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rigidbody.AddForce(movement * speed);

        if (Mathf.Abs(transform.localScale.x - moveHorizontal) > 1)//flip the image
        {
            transform.localScale *= new Vector2(-1,1);
        }

        //handle which sprite to use
        int which = Mathf.Abs(rigidbody.velocity.x) > Mathf.Abs(rigidbody.velocity.y) ? 0 : 1;
        float higherSpeed = which == 0 ? moveHorizontal : moveVertical;

        if(Mathf.Abs(higherSpeed) < .5)
        {
            if (renderer.sprite != idleForward && renderer.sprite != idleSide) {
                renderer.sprite = which == 0 ? idleSide : idleForward;
            }
        }
        else
        {
                //cycle though sprites
                walkChangeCounter++;
                if(walkChangeCounter > stepSpeed)
                {
                    walkNum = (walkNum + 1) % 2;
                    walkChangeCounter = 0;
                }
                if (walkNum == 0)
                {
                    renderer.sprite = which == 0 ? walkSide1 : walkForward1;
                }
                else
                {
                    renderer.sprite = which == 0 ? walkSide2 : walkForward2;
                }           
        }

    }

}
