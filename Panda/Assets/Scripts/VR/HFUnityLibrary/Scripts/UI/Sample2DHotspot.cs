using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using HappyFinish.VR;

public class Sample2DHotspot : Hotspot
{
    public float ScaleFactor = 1.25f;
    private Image image;

    private new void Awake()
    {
        base.Awake();
        image = GetComponent<Image>();
    }

    protected override void ClickBehaviour()
    {
        //image.color = Color.red;
        //StartCoroutine(ScaleChange());
    }

    protected override void EnterBehaviour()
    {
        //image.color = Color.green;
        transform.localScale *= ScaleFactor;
    }

    protected override void ExitBehaviour()
    {
        //image.color = Color.white;
        transform.localScale = Vector3.one;
    }

    protected override void StayBehaviour(float deltaTime)
    {
        //Debug.Log("StayBehaviour deltaTime: " + deltaTime);
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
