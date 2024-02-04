using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    Rigidbody2D rb;
    CapsuleCollider2D playerCol;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] Transform groundCheck2;

    PlayerInput playerInput;
    Vector2 moveInput;
    SpriteRenderer playerSprite;
    Animator playerAnimator;
    

    [Header("Move Stats")]
    public float speed;
    public float jumpForce;
    public bool cMoon;
    public float mx;
    
   



    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       playerCol = GetComponent<CapsuleCollider2D>();
       playerInput = GetComponent<PlayerInput>();
       playerSprite = GetComponent<SpriteRenderer>();
       playerAnimator = GetComponent<Animator>();
       cMoon = false;
       mx = 0;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        
        

    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector3(moveInput.x * speed, rb.velocity.y, 0);
        if (moveInput.x > 0) 
        { 
            transform.rotation = Quaternion.Euler(mx, 0, 0);
            playerAnimator.SetBool("Run", true);
        }
        else if (moveInput.x < 0) 
        { 
            transform.rotation = Quaternion.Euler(mx, 180, 0);
            playerAnimator.SetBool("Run", true);
        }
        else 
        {
            playerAnimator.SetBool("Run", false);
        }
    }


    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }
 
   

    public void Jump(InputAction.CallbackContext context)
    {
       if (isGrounded()  && context.started)
        {
            if (rb.gravityScale > 0)
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                
                playerAnimator.SetBool("Jump", true);
            }
            else if (rb.gravityScale < 0)
            {
                rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);

                playerAnimator.SetBool("Jump", true);
            }

        }
       


    }



   


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Buttom"))
        {
            cMoon = true;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerAnimator.SetBool("Jump", false); 
        }
    }

    public void CMoon(InputAction.CallbackContext context)
    {
        if (cMoon == true)
        {
            rb.gravityScale = -1;
            transform.rotation = Quaternion.Euler(180, 0, 0);
            mx = 180;
            playerAnimator.SetBool("Run", true);
        }
    }

    

    
}
