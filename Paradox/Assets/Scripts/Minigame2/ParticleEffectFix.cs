using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectFix : MonoBehaviour {

    public string sortingLayerName;
    public int sortingOrder;

	void Start () {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "player";
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingOrder = -1;
    }
	
	void Update () {
		
	}
}
