using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScriptHorizontal : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb;
    [SerializeField] private Transform player;

    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip death;
    private AudioSource musicSource;
    private AudioSource deathSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if ((transform.position.x - player.transform.position.x >= 40) || 
            (transform.position.x - player.transform.position.x <= -40))
            rb.velocity = Vector2.left * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-10, -4, 0);
            musicSource = collision.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
            musicSource.Pause();
            StartCoroutine("PauseMusic");
            deathSource = collision.gameObject.transform.GetChild(2).GetComponent<AudioSource>();
            deathSource.PlayOneShot(death);
        }
    }

    IEnumerator PauseMusic()
    {
        yield return new WaitForSecondsRealtime(3);
        musicSource.UnPause();
    }
}
