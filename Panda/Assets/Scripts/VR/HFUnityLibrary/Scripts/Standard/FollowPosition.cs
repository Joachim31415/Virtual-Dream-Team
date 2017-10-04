using UnityEngine;
using System.Collections;

public class FollowPosition : MonoBehaviour
{
    [Header("Offset between the object and the target")]
    public Vector3 offset = new Vector3(0, 0, 4);
    public bool autoCalculateOffset = true;

    public Transform target;

    [Header("Do not follow the Y position")]
    public bool ignoreY = false;
    private Vector3 initialPosition;
    private Vector3 newPosition;

    [Header("Follow just at Start?")]
    public bool updateFollow = false;

    public bool smooth = false;
    public float speed = 3f;

    public bool drawDebug = true;

    //private void OnEnable()
    //{
    //    if (autoCalculateOffset)
    //    {
    //        offset = CalculateOffset();
    //        Debug.Log("OnEnable CalculateOffset: " + CalculateOffset());
    //    }
    //}

    private void Awake()
    {
        if (!target)
        {
            target = Camera.main.transform;

            if (!target)
                Debug.LogWarning("FollowPosition There is no target");
        }

        initialPosition = transform.position;

        if (autoCalculateOffset)
        {
            offset = CalculateOffset();
        }
    }

    private void Start()
    {
        //Debug.Log("Start CalculateOffset: " + CalculateOffset());
        //offset = CalculateOffset();
        newPosition = target.position + offset;

        if (ignoreY)
        {
            newPosition.y = initialPosition.y;
        }

        transform.position = newPosition;
    }

    private void LateUpdate()
    {
        //Debug.Log("CalculateOffset: " + CalculateOffset());
        if (updateFollow)
        {
            if (smooth)
            {
                newPosition = Vector3.Lerp(transform.position, target.position + offset, speed * Time.deltaTime);
            }
            else
            {
                newPosition = target.position + offset;                
            }

            if (ignoreY)
            {
                newPosition.y = initialPosition.y;
            }

            transform.position = newPosition;
        }
#if UNITY_EDITOR
        if (drawDebug)
            Debug.DrawLine(transform.position, target.position, Color.cyan);
#endif
    }

    private Vector3 CalculateOffset()
    {
        return transform.position - target.position;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }
}
