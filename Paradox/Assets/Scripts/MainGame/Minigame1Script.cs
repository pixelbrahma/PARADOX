using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minigame1Script : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private Transform player;
    private float back = 2;
    private bool active = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = false;
        game.SetActive(active);
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);      
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                player.position -= new Vector3(back, 0, 0);
                game.SetActive(true);
                active = true;
            }
            else if (active == true)
            {
                active = false;
                game.SetActive(false);
            }
        }
    }
}
