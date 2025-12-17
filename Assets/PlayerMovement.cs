using UnityEngine;

public class AutoRunner : MonoBehaviour
{
    public float speed = 6f; //set move speed
    public float jumpForce = 10f; //set force of jump

    private Rigidbody2D rb;
    private bool isGrounded; //check if player is touching ground
    public bool isDead = false; //this is so the player doesn't stop moving unless they're dead


    void Start()
    { //get rigidbody component attached to player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return; //if the player dies stop running code
        //always move right
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y); //constantly move player to right

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) //checks the space bar is pressed and the player is on the ground
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision) //called when player touches another object
    {
        isGrounded = true; //player is on ground
    }

    void OnCollisionExit2D(Collision2D collision)//called when player stops touching object
    {
        isGrounded = false; //player is off ground
    }
}
