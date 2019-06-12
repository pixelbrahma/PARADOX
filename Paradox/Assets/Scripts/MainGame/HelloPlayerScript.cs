using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelloPlayerScript : MonoBehaviour
{
    private TextMesh helloText;

    private void Start()
    {
        helloText = GetComponent<TextMesh>();
        helloText.text = " HELLO " +  PlayerPrefs.GetString("PlayerName").ToUpper();
        Destroy(this.gameObject, 5);
    }
}
