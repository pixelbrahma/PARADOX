using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] public static int count = 0;
    private AudioSource collectibleSource;
    [SerializeField] private AudioClip collectibleSound;

    private void Update()
    {
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collectibleSource = collision.gameObject.transform.GetChild(3).GetComponent<AudioSource>();
            collectibleSource.PlayOneShot(collectibleSound);
            Destroy(this.gameObject);
            count++;
        }
    }
}
