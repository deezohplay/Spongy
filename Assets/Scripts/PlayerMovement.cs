using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // all game variables declared
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    public Joystick joystick;
    public bool isJumping;

    // start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // update is called once per frame
    void Update()
    {
        //moves the player left and right
        if(joystick.Horizontal >= .2f)
        {
            moveHorizontal = speed;
        }
        else if(joystick.Horizontal <= -.2f)
        {
            moveHorizontal = -speed;
        }
        else
        {
            moveHorizontal = 0f;
        }
        rb.velocity = new Vector2(speed * moveHorizontal, rb.velocity.y);

        //lets the player jump only if on the ground
        if(joystick.Vertical >= .5f && isJumping == false)
        {
            moveVertical = jump;
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
