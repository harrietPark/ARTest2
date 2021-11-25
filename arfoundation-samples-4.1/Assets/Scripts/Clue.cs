using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : Interactable
{
    [Tooltip("Debug log message to show when the clue is touched")]
    public string message;

    private Checkpoint checkpoint;

    private void Awake()
    {
        checkpoint = transform.parent.GetComponent<Checkpoint>();
    }

    public override void OnTouch()
    {
        Debug.Log(message);
        checkpoint.MoveToNextCheckpoint();
    }

}
