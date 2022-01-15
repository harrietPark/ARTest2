using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinLetter : Interactable
{
    public GameObject goblinLetterUI;
    public override void OnTouch()
    {
        goblinLetterUI.SetActive(true);
    }
}
