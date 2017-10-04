using UnityEngine;
using System.Collections;
using HappyFinish.VR;
using HappyFinish.Project;

namespace HappyFinish.VR
{
[RequireComponent(typeof(SpriteRenderer))]
	public class Reticle : MonoBehaviour
	{
		// Events and delegates


		// ==========================
		// Public vars
		// ==========================
		public bool alignToTarget = true;
		public bool alignToSurface = true;
		public float maxDistance = 4f;
		public float scalePerDistanceUnit = 0.25f;
		public float distanceFromCollision = 0.01f;

		// ==========================
		// Private vars
		// ==========================
		private float lastDistance;
		private GazeGestureVR gazeRayCaster;
		private Transform mTransform;
		private Transform cameraTransform;
		private SpriteRenderer spriteRenderer;
		private Vector3 newPosition;
		private float nearClipPlaneDistance;

		// ==========================
		// Unity Default Methods
		// ==========================
		private void Awake()
		{
			mTransform = transform;
			cameraTransform = Camera.main.transform;
			spriteRenderer = GetComponent<SpriteRenderer>();
		}

		private void Start()
		{
			gazeRayCaster = PlatformManager.Instance.GetGazeGestureVR();
			lastDistance = maxDistance;

			SetReticlePosition(maxDistance);
			newPosition = new Vector3(0, 0, maxDistance);

			nearClipPlaneDistance = Camera.main.nearClipPlane;
		}

		private void LateUpdate()
		{
			NewTry();
			//return;
			//Original();
		}

		// ==========================
		// Your public methods
		// ==========================
		public void ShowReticle(bool showIt = true)
		{
			spriteRenderer.enabled = showIt;
		}

		// ==========================
		// Your private methods
		// ==========================
		private void SetReticlePosition(float distance)
		{
			mTransform.position = cameraTransform.forward * distance;
			mTransform.LookAt(cameraTransform.position);
			mTransform.localScale = Vector3.one * distance * scalePerDistanceUnit;
		}

		private void NewTry()
		{
			if (alignToTarget)
			{
				if (gazeRayCaster.rayResult.IsValid)
				{
					lastDistance = Mathf.Clamp((cameraTransform.position - gazeRayCaster.rayResult.Position).magnitude, 2f, maxDistance * 2);

					//var newLocalPos = Vector3.forward * lastDistance + (gazeRayCaster.rayResult.Normal * distanceFromCollision);

					//Debug.Log("Vector3.forward: " + Vector3.forward + " rayResult.Position: " + gazeRayCaster.rayResult.Position + " mag: " + lastDistance + " newPos: " + Vector3.forward * lastDistance + (gazeRayCaster.rayResult.Normal * distanceFromCollision));

					// Position
					newPosition.z = (Vector3.forward * lastDistance + (gazeRayCaster.rayResult.Normal * distanceFromCollision)).z;
					//new Vector3(0, 0, (Vector3.forward * lastDistance + (gazeRayCaster.rayResult.Normal * distanceFromCollision)).z);
					mTransform.localPosition = newPosition;

					// Rotation
					if (alignToSurface)
						mTransform.rotation = Quaternion.LookRotation(gazeRayCaster.rayResult.Normal);

					// Scale
					mTransform.localScale = Vector3.one * lastDistance * scalePerDistanceUnit;

				}
				else
				{
					if (alignToSurface)
						mTransform.localRotation = Quaternion.LookRotation(Vector3.zero);
				}
			}
		}

		private void Original()
		{
			if (alignToTarget)
			{
				if (gazeRayCaster.rayResult.IsValid)
				{
					mTransform.position = gazeRayCaster.rayResult.Position + gazeRayCaster.rayResult.Normal * distanceFromCollision;
					mTransform.position = cameraTransform.position + cameraTransform.forward * gazeRayCaster.rayResult.Depth;
					//lastDistance = (mTransform.position - cameraTransform.position).magnitude; //gazeRayCaster.depth;
					lastDistance = gazeRayCaster.rayResult.Depth;

					if (alignToSurface)
					{
						mTransform.rotation = Quaternion.LookRotation(gazeRayCaster.rayResult.Normal);
					}
					mTransform.localScale = Vector3.one * lastDistance * scalePerDistanceUnit;
				}
				else
				{
					SetReticlePosition(lastDistance);
				}
			}
		}
	}

}