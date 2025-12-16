using UnityEngine;

public class AutoRunner : MonoBehaviour
{
    public float speed = 6f;
    public float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded;
    public bool isDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;
        //always move right
        rb.linearVelocity = new Vector2(speed, rb.linearVelocity.y);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
