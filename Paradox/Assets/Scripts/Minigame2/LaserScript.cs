using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour {

    public Sprite laserOnSprite;
    public Sprite laserOffSprite;

    public float interval = 0.5f;
    public float rotationSpeed = 0.0f;

    private bool isLaserOn = true;
    private float timeTillNextToggle;

    Collider2D col;
    SpriteRenderer spriteRenderer;

    void Start () {
        timeTillNextToggle = interval;
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	void FixedUpdate () {

        timeTillNextToggle -= Time.fixedDeltaTime;

        if (timeTillNextToggle <= 0)
        {
            isLaserOn = !isLaserOn;
            col.enabled = isLaserOn;

            if (isLaserOn)
                spriteRenderer.sprite = laserOnSprite;
            else
                spriteRenderer.sprite = laserOffSprite;

            timeTillNextToggle = interval;
        }

        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.fixedDeltaTime);
	}
}
