using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour
{
    public enum RotationAxis
    {
        X,
        Y,
        Z
    }
    public RotationAxis axis = RotationAxis.Y;
    public float degreesPerSecond = 60;
	public Vector3 initialRotation;
	bool init = false;

    private void Awake()
    {
	    Init();
    }

	private void Init()
	{
		if (!init)
		{
			initialRotation = transform.eulerAngles;
		}
		init = true;
	}

	void OnDisable()
	{
		Init();
		transform.eulerAngles = initialRotation;
	}

    // Update is called once per frame
    void Update()
    {
        switch (axis)
        {
            case RotationAxis.X:
                transform.Rotate(Vector3.right, degreesPerSecond * Time.deltaTime, Space.World);
                break;
            case RotationAxis.Y:
                transform.Rotate(Vector3.up, degreesPerSecond * Time.deltaTime, Space.World);
                break;
            case RotationAxis.Z:
                transform.Rotate(Vector3.forward, degreesPerSecond * Time.deltaTime, Space.World);
                break;
            default:
                break;
        }
    }
}
