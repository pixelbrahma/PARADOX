using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    private TextMesh scrollText;
    [SerializeField] private float scrollSpeed = 0.03f;

    void Start()
    {
        scrollText = GetComponent<TextMesh>();
        scrollText.text = "ZZ  You wake up.\n" +
            "Well..  that was a \n" +
            "wierd dream. What were\n" +
            "those things and where \n" +
            "were you?? You sit \n" +
            "up. Its morning already.\n" +
            "You lazily glance around\n" +
            "the room. Your eyes spot\n" +
            "something shining on the \n" +
            "table beside. You rub your\n" +
            "eyes again to make sure.\n" +
            "-----UNBELIEVABLE-----\n" +
            "the 2 shining crystals from \n" +
            "your dream are right there.\n" +
            "You pinch yourself,\n" +
            "just to be sure.\n" +
            "-----INSANE------- \n" +
            "WAS IT A DREAM OR \n" +
            " SOMETHING ELSE ? \n" + 
            " AN ABNORNAL  \n" + 
            "    ANAMOLY  \n" +
            "      -TRULY-    \n" +  
            "        -A-      \n\n\n\n\n\n\n" +
            "  --- PARADOX --- ";
    }

    void Update()
    {
        transform.position += new Vector3(0f, scrollSpeed, scrollSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            scrollSpeed *= 5;
        }
    }
}
