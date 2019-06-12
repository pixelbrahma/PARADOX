using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentControllerX : MonoBehaviour {
    private Rigidbody rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    private GameObject player;
    public static string leveltext;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.right;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb.velocity = direction * moveSpeed;
        if((Mathf.Abs(transform.position.y - player.transform.position.y) < 1.2f) &&
                (Mathf.Abs(transform.position.x - player.transform.position.x) < 1.2f))
        {
             direction = player.transform.position - transform.position;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Wall")
        {
            direction *= -1;
        }
        else if (collision.collider.gameObject.tag == "Player")
        {
            leveltext = PlayerController1.text;
            PlayerController1.text = " GAME OVER !! ";
        }
    }
}
