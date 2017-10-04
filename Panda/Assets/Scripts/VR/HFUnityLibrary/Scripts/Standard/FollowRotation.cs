using UnityEngine;
using System.Collections;

public class FollowRotation : MonoBehaviour
{
    public Transform target;

    public bool smooth = false;

    [Header("Apply if smooth is true (checked)")]
    public float speed = 2f;
    public bool followYAxis = false;
    public bool billboard = true;

    Vector3 distance;
    float initialY;
    
    void Awake()
    {
        if (!target)
        {
            target = Camera.main.transform;

            if (!target)
                Debug.LogWarning("FollowRotation There is no target");
        }
    }

    void Start()
    {
        if (!smooth)
        {
            transform.SetParent(target.transform);
            return;
        }

        initialY = transform.position.y;
        distance = transform.position - target.transform.position;
    }

    void LateUpdate()
    {
        if (!smooth)
            return;

        Vector3 newPosition = (target.transform.position + (target.transform.forward * distance.magnitude));

        if (!followYAxis)
            newPosition.y = initialY;

        if (billboard)
            BillboardBehaviour();

        transform.position = Vector3.Slerp(transform.position, newPosition, speed * Time.deltaTime);
    }

    void BillboardBehaviour()
    {
        transform.LookAt(transform.position + target.transform.rotation * Vector3.forward, target.transform.rotation * Vector3.up);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
