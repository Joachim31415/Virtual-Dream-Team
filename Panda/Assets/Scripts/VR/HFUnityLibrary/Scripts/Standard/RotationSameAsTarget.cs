using UnityEngine;
using System.Collections;

public class RotationSameAsTarget : MonoBehaviour
{
    public Transform target;

    private Vector3 selfRotation;
    private Vector3 targetRotation;

    private void Awake()
    {
        selfRotation = transform.rotation.eulerAngles;

        if (!target)
        {
            target = Camera.main.transform;
            targetRotation = target.transform.rotation.eulerAngles;

            if (!target)
                Debug.LogWarning("FollowRotation There is no target");
        }
    }

    private void LateUpdate()
    {
        // Rotate in Y // TODO, rotate diferent axis
        targetRotation = target.transform.rotation.eulerAngles;
        targetRotation.x = selfRotation.x;
        targetRotation.z = selfRotation.z;

        transform.rotation = Quaternion.Euler(targetRotation);
    }
}
