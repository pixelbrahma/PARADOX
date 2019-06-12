using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBoss : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10f;

    private Rigidbody RB;
    public bool isGrounded;
    public Transform GroundCheck;
    public float Radius;
    public LayerMask whatisGround;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement();
        if (Input.GetKey(KeyCode.Space))
        {
            jump();
        }
    }

    void HandleMovement()
    {
        float _Horizontal = Input.GetAxisRaw("Horizontal");
        RB.velocity = new Vector2(_Horizontal * _speed, RB.velocity.y);
    }

    void jump()
    {
        RB.AddForce(new Vector3(0.0f, 1f, 0.0f), ForceMode.Impulse);
    }
}
