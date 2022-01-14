using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : Interactable
{
    public override void OnTouch()
    {
        Debug.Log("glass touched");
        
    }
}
