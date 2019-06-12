using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private AudioClip music;
    [SerializeField] private AudioClip death;
    private AudioSource musicSource;
    private AudioSource deathSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = new Vector3(-10, -4, 0);
            musicSource =  collision.gameObject.transform.GetChild(1).GetComponent<AudioSource>();
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
