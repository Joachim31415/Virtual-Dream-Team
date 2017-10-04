using UnityEngine;
using System.Collections;

public class DrawRayFromCamera : MonoBehaviour
{

    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * 100f, Color.red);
    }
}