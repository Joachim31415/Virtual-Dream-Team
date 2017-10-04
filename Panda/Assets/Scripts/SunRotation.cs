using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
	public GameObject Rays;
	public GameObject Stars;
	public Material DaySkybox;
	public Material NightSkybox;

	// This script makes the light/sun rotate
	void Start () {
		Rays.SetActive(false);
		Stars.SetActive (false);
	}
	
	// Change the Tilt Angle parameter in Unitys Inspector Tab to change the rotation speed
	public float tiltAngle = 30.0F;
	void Update() {
		
		transform.rotation *= Quaternion.Euler(tiltAngle * Time.deltaTime, 0, 0);

		if (Rays != null && Stars != null)
		{
			Debug.Log(transform.rotation.eulerAngles.x +" condition "+ (transform.rotation.eulerAngles.x >= 10.78163 && transform.rotation.eulerAngles.x <= 360));
			// condition here
			if ((transform.rotation.eulerAngles.x >= 10 && transform.rotation.eulerAngles.x <= 90) )
			{
				Day ();
			}
			else
			{
				Night ();
			}
		}


	}

	private void Day()
	{
		Rays.SetActive (true);
		Stars.SetActive (false);
		RenderSettings.skybox = DaySkybox;
	}

	private void Night()
	{
		Rays.SetActive(false);
		Stars.SetActive (true);
		RenderSettings.skybox = NightSkybox;
	}
}
