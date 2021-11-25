using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButton : Interactable
{
    [Tooltip("Debug log message to show when the UI button is touched")]
    public string message;

    public GameObject letter;

    public override void OnTouch()
    {
        Debug.Log(message);
        letter.gameObject.SetActive(false);
    }
}

