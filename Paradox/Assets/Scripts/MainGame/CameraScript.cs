using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float jumpX = 50;
    [SerializeField] private Transform player;
    private float guard = 2;

    private void Update()
    {
        if(player.position.x - transform.position.x > jumpX/2)
        {
            transform.position += new Vector3(jumpX - guard, 0, 0);
        }
        else if(transform.position.x -  player.position.x > jumpX/2)
        {
            transform.position -= new Vector3(jumpX - guard, 0, 0);
        }
    }
}
