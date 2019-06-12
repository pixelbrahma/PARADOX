using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartOnClick : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("PlayerNameScene");
    }
}
