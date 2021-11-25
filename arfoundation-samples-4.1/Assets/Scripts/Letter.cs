using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : Interactable
{
    [Tooltip("Debug log message to show when the letter is touched")]
    public string message;

    public GameObject letter;

   // private bool isTouched = false;

    public override void OnTouch()
    {
        this.gameObject.SetActive(false);
        letter.SetActive(true);
        //isTouched = true;
    }

}
