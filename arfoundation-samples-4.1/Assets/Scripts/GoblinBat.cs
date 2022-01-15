using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBat : Interactable
{
    private bool isTouched = false;
    public GameObject bat;
    public GameObject thisBat;
    public static bool gotBat = false;
    public GameObject batInstruction;

    public override void OnTouch()
    {
        isTouched = true;
        if (isTouched)
        {
            bat.SetActive(true);
            thisBat.SetActive(false);
            isTouched = false;
            gotBat = true;
            batInstruction.SetActive(true);
        }
    }
}
