using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private bool jump;
    private float horizontal;
    private bool landed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.UpArrow) && landed == true)
            jump = true;
    }

    void FixedUpdate()
    {
        float yVelocity = rb.velocity.y;
        float xVelocity = Vector2.right.x * horizontal * moveSpeed;
        rb.velocity = new Vector2(xVelocity, yVelocity);
        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce);
            jump = false;
            landed = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        landed = true;
    }
}
