using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        MapController.count = 0;
        SceneManager.UnloadSceneAsync("Level1");
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }
}
