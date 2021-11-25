using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : Interactable
{
    [Tooltip("Debug log message to show when the letter is touched")]
    public string message;

    public GameObject letterInstruction;
    
    public override void OnTouch()
    {
        this.gameObject.SetActive(false);
        letterInstruction.SetActive(true);
    }
}
