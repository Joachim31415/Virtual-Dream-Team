using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    public Transform cameraTarget;
    public bool updateBillboard = false;

    private void Awake()
    {
        if (!cameraTarget)
        {
            cameraTarget = Camera.main.transform;

            if (!cameraTarget)
                Debug.LogWarning("Billboard, there is no camera target");
        }        
    }

    private void Start()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - cameraTarget.position);
    }

    private void LateUpdate()
    {
        if (updateBillboard)
            transform.rotation = Quaternion.LookRotation(transform.position - cameraTarget.position);
    }
}
