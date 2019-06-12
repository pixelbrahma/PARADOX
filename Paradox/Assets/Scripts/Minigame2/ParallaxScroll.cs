using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour {

    public Renderer background;
    public Renderer foreground;

    public float backgroundSpeed = 0.02f;
    public float foregroundSpeed = 0.06f;

	void Start () {
		
	}
	
	
	void Update () {

        float backgroundOffset = Time.timeSinceLevelLoad * backgroundSpeed;
        float foregroundOffset = Time.timeSinceLevelLoad * foregroundSpeed;

        background.material.mainTextureOffset = new Vector2(backgroundOffset, 0);
        foreground.material.mainTextureOffset = new Vector2(foregroundOffset, 0);
		
	}
}
