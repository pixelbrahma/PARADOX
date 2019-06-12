using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDropper : MonoBehaviour
{
    [SerializeField] private float dropSpeed;
    private Rigidbody2D rb;
    Vector3 Originalposition; 

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Originalposition = transform.position;
    }

    void Update()
    {
        rb.velocity = Vector2.down * dropSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = Originalposition;
    }
}
