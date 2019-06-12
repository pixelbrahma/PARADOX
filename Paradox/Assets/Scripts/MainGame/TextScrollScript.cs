using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextScrollScript : MonoBehaviour
{
    private TextMesh scrollText;
    [SerializeField] private float scrollSpeed = 0.03f;

    void Start()
    {
        scrollText = GetComponent<TextMesh>();
        scrollText.text = "You come home. It\n" +
            "has been a very long\n" +
            "day.You are really\n" +
            "tired and sleepy. You\n" +
            "freshen up and grab\n" +
            "a bite to eat.The food\n" +
            "does not seem very\n" +
            "tasty.Or you are too\n" +
            "tired to appreciate it.\n" +
            "You hit the sack. Boy\n" +
            "does it feel good! You\n" +
            "fall asleep immediately.\n" +
            "TRAVELLING INTO \n" +
            "YOUR DREAMS............\n" +
            "...........................";
    }

    void Update()
    {
        transform.position += new Vector3(0f, scrollSpeed, scrollSpeed);
        if (transform.position.y > 100)
            SceneManager.LoadScene("WorldGreen");

        if(Input.GetKeyDown(KeyCode.Space))
        {
            scrollSpeed *= 5;
        }
    }
}
