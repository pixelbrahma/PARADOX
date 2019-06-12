using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject crystalPrefab;
    [SerializeField] private Transform crystal;
    GameObject crystal1;

    void Start()
    {
        
    }

    
    void Update()
    {
        if(minigameText.minigames == 1)
        {
            crystal1 = Instantiate(crystalPrefab, transform.position, Quaternion.identity);
            crystal1.transform.parent = transform;
        }
        if(minigameText.minigames == 2)
        {
            GameObject crystal2 = Instantiate(crystalPrefab, crystal.position, Quaternion.identity);
            crystal2.transform.parent = transform;
        }
    }
}
