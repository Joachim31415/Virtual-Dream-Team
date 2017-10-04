using UnityEngine;
using System.Collections;
using System;
using HappyFinish.VR;

public class Sample3DHotspot : Hotspot
{
    private Material material;
    private float semitransparent = 0.5f;
    private Color behaviourColor;
    
    private new void Awake()
    {
        base.Awake();
        material = GetComponent<Renderer>().sharedMaterial;
    }

    protected override void ClickBehaviour()
    {
        behaviourColor = Color.red;
        behaviourColor.a = semitransparent;
        material.color = behaviourColor;
        
        StartCoroutine(ScaleChange());
    }

    protected override void EnterBehaviour()
    {
        behaviourColor = Color.green;
        behaviourColor.a = semitransparent;
        material.color = behaviourColor; 
    }

    protected override void ExitBehaviour()
    {
        behaviourColor = Color.white;
        behaviourColor.a = semitransparent;
        material.color = behaviourColor;
    }

    protected override void StayBehaviour(float deltaTime)
    {
        Debug.Log("StayBehaviour deltaTime: " + deltaTime);
    }

    private IEnumerator ScaleChange()
    {
        transform.localScale *= 1.1f;
        yield return new WaitForSeconds(0.5f);
        transform.localScale /= 1.1f;
        yield return new WaitForSeconds(0.05f);
        EnterBehaviour();
    }
}
