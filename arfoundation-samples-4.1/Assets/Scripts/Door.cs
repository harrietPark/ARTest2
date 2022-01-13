using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator animator;
    public ARTapToPlaceObject arTapToPlaceObject;
    public override void OnTouch()
    {
        Debug.Log("Door touched");
        animator.SetTrigger("isOpen");
        arTapToPlaceObject.enabled = false;
    }
}
