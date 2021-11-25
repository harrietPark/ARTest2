using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Envelope : Interactable
{
    [Tooltip("Debug log message to show when the letter is touched")]
    public string message;

    public GameObject letterInstruction;

    private bool isTouched = false;

    public override void OnTouch()
    {
        this.gameObject.SetActive(false);
        letterInstruction.SetActive(true);
        isTouched = true;
    }
}
