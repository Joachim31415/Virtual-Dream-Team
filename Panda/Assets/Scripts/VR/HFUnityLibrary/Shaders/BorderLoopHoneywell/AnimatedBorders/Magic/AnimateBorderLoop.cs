using UnityEngine;
using System.Collections;

public class AnimateBorderLoop : MonoBehaviour
{
    private float angle = 0;
    public float speed = 1.0f;

	// Use this for initialization
	void Start ()
    {
        angle = 0;
    }
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.GetComponent<SpriteRenderer>().sharedMaterial.SetFloat("_Angle", angle);
        angle += Time.deltaTime * speed;
        angle = angle % 360.0f;
    }
}
