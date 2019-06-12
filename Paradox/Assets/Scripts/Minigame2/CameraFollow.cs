using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject targetObject;

	void Start () {
		
	}
	
	void Update () {
	    float targetObjectX = targetObject.transform.position.x;
        Vector3 newCameraPosition = transform.position;
        newCameraPosition.x = targetObjectX;
        transform.position = newCameraPosition;
    }
}
