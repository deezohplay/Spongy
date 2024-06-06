using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // All game variables declared
    public float speed;
    public float jump;
    private Rigidbody2D rb;
    private float moveHorizontal;
    private float moveVertical;
    public Joystick joystick;
    public bool isJumping;
    public Button jumpButton;

    public static PlayerMovement Instance
    {
        get; set;
    }

    void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Locates the rigid component on the game object
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.isGameOn == true)
        {
            //Moves the player left and right
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
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    // Adds a vertical force on the player to act against gravitational force
    public void Jump()
    {
        //lets the player jump only if on the ground
        if(isJumping == false && GameManager.Instance.isGameOn == true)
        {
            moveVertical = jump;
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    // Detects collision of the player with the ground
    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}
