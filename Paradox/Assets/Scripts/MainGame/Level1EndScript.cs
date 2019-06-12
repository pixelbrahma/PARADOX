using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1EndScript : MonoBehaviour
{
    [SerializeField] private GameObject particleSys;
    [SerializeField] private GameObject maingame;
    private float moveUp = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(CollectibleScript.count >=75 && minigameText.minigames >= 2)
            {
                moveUp = 0.01f;
                particleSys.SetActive(true);
                collision.gameObject.SetActive(false);
                maingame.SetActive(false);
            }
        }
    }

    private void Update()
    {
        transform.Translate(0, moveUp, 0);
        if(transform.position.y >= 10)
        {
            moveUp = 0.5f;
        }
        if(transform.position.y >= 100)
        {
            SceneManager.LoadScene("StoryOutro");
        }
    }
}
