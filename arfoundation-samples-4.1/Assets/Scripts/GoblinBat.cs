using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GoblinBat : Interactable
{
    private bool isTouched = false;
    public ARSessionOrigin arOrigin;
   // public Transform batPos;

    public override void OnTouch()
    {
        isTouched = true;
        if (isTouched)
        {
            this.transform.parent = arOrigin.transform.Find("AR Camera").gameObject.transform;
            //this.transform.parent = batPos;
        }
    }
}
