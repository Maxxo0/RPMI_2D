using System.Collections;
using System.Collections.Generic;
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


    [Header("Move Stats")]
    public float speed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<CapsuleCollider2D>();
        playerInput = GetComponent<PlayerInput>();
        playerSprite = GetComponent<SpriteRenderer>();
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

        if (moveInput.x > 0) { playerSprite.flipX = false; }
        else if (moveInput.x < 0) { playerSprite.flipX= true; }
    }


    public void CMoon(InputAction.CallbackContext context)
    {
        rb.gravityScale = -1;
        playerSprite.flipY = true;
    }


}
