using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class minigameText : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public static int minigames = 0;

    void Start()
    {
        countText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        countText.text = minigames.ToString() + " / 2";
    }
}
