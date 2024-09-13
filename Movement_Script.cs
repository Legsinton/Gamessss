using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    void Start()
    {
        Camera cam = Camera.main;

    }
    //velocity for movement
    Vector2 velocity = Vector2.zero;
    Vector2 inputMove;
    public float velocityJump;
    public float acceleration = 2.0f;
    public float deacceleration = 2.0f;
    public float maxSpeed = 5.0f;
    //velocity for jump
    public Rigidbody2D rb;
    public float jumpAmount = 35;
    public float gravityScale = 10;
    public float fallingGravityScale = 40;

    void Movement()

    {

        inputMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (inputMove != Vector2.zero)


        {

            velocity += acceleration * Time.deltaTime * inputMove.normalized;
            
        }

        else 
        {
            velocity = Vector2.Lerp(velocity, Vector2.zero, deacceleration * Time.deltaTime);
        }

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }

        if (rb.velocity.y >= 0)
        {
            rb.gravityScale = gravityScale;
        }
        else if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallingGravityScale;
        }

        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        transform.position += (Vector3)velocity * Time.deltaTime;
        
    }

    void Update()
    {
        Movement();
    }
  
}
