using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour {

	// This script makes the light/sun rotate
	void Start () {
		
	}
	
	// Change the Tilt Angle parameter in Unitys Inspector Tab to change the rotation speed
	public float tiltAngle = 30.0F;
	void Update() {
		
		transform.rotation *= Quaternion.Euler(tiltAngle * Time.deltaTime, 0, 0);

	}
}
