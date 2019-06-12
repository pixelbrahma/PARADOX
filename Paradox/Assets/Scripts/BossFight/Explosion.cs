using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 0.5f);
    }
}
