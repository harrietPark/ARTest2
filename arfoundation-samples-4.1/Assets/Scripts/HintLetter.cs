using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintLetter : Interactable
{
    public GameObject hintLetterUI;
    public GameObject letterParticle;
    public override void OnTouch()
    {
        Debug.Log("hint letter touched");
        hintLetterUI.SetActive(true);
        letterParticle.SetActive(false);
    }
}
