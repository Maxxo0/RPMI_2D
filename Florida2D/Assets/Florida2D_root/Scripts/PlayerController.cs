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
    PlayerInput playerInput;
    Vector2 moveInput;
    SpriteRenderer playerSprite;
    Animator playerAnimator;
    [SerializeField] GameObject groundCheck;

    [Header("Move Stats")]
    public float speed;
    public float jumpForce;
    public bool cMoon;
    public bool isGrounded;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
        playerAnimator = GetComponent<Animator>();
        cMoon = false;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        if (isGrounded == true ) { playerAnimator.SetBool("Jump", false); }
        

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
            transform.rotation = Quaternion.Euler(0, 0, 0);
            playerAnimator.SetBool("Run", true);
        }
        else if (moveInput.x < 0) 
        { 
            transform.rotation = Quaternion.Euler(0, 180, 0);
            playerAnimator.SetBool("Run", true);
        }
        else 
        {
            playerAnimator.SetBool("Run", false);
        }
    }


 

    public void Jump(InputAction.CallbackContext context)
    {
        if (isGrounded == true) 
        {
            
            if (rb.gravityScale > 0) 
            { 
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); 
                isGrounded = false;
                playerAnimator.SetBool("Jump", true); 
            }
            else if (rb.gravityScale < 0) 
            { 
                rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
                isGrounded = false;
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


    public void CMoon(InputAction.CallbackContext context)
    {
        if (cMoon == true)
        {
            rb.gravityScale = -1;
            playerSprite.flipY = true;
        }
    }

    

    
}
