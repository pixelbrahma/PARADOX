using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GetPlayerDetails : MonoBehaviour
{
    public GameObject nameField;
    private string playerName;

    public void GetPlayerName()
    {
        playerName = nameField.GetComponent<TMP_InputField>().text;
        PlayerPrefs.SetString("PlayerName", playerName);
        Debug.Log(PlayerPrefs.GetString("PlayerName"));
    }

    public void LoadWorldGreen()
    {
        SceneManager.LoadScene("StoryIntro");
    }
}
