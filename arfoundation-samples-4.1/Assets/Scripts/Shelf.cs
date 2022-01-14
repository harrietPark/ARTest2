using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : Interactable
{
    public Animator anim;
    private bool isTouched;
    public override void OnTouch()
    {
        Debug.Log("shelf touched");
        anim.enabled = true;
        
        anim.SetBool("isClosed", isTouched);
        isTouched = !isTouched;
    }
}
