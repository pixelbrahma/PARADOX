using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextOrbs : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public static int minigames = 0;

    void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        countText.text = CollectibleScript.count.ToString() + " / 76";
    }
}
