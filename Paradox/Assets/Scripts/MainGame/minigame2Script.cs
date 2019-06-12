using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class minigame2Script : MonoBehaviour
{
    [SerializeField] private GameObject game;
    [SerializeField] private Transform player;
    private float back = 2;
    private bool active = true;
    [SerializeField] private GameObject cam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        active = false;
        game.SetActive(active);
        cam.GetComponent<AudioListener>().enabled = false;
        SceneManager.LoadScene("FirstScene", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (active == false)
            {
                player.position -= new Vector3(back, 0, 0);
                game.SetActive(true);
                cam.GetComponent<AudioListener>().enabled = true;
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
