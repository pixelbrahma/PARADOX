using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelldoneScript : MonoBehaviour
{
    private TextMesh helloText;

    private void Start()
    {
        helloText = GetComponent<TextMesh>();
        helloText.text = "WELL DONE " + PlayerPrefs.GetString("PlayerName").ToUpper();
        Destroy(this.gameObject, 5);
    }
}
