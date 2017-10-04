using UnityEngine;
using System.Collections;
using System;
using HappyFinish.VR;

public class TestHotspot : Hotspot
{
    protected override void ClickBehaviour()
    {
        Debug.Log("ClickBehaviour");
    }

    protected override void EnterBehaviour()
    {
        Debug.Log("EnterBehaviour");
    }

    protected override void ExitBehaviour()
    {
        Debug.Log("ExitBehaviour");
    }

    protected override void StayBehaviour(float deltaTime)
    {
        Debug.Log("StayBehaviour deltaTime: " + deltaTime);
    }
}
