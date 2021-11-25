using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [Header("Image Tracking")]
    [Tooltip("Information about the image trigger at this checkpoint")]
    public string imageName;
    public Vector3 imagePosition;
    public bool imageVisible;

    [Header("Display Object")]
    [Tooltip("The object to display on top of the tracked image")]
    public GameObject displayObj;

    [Header("Location Tracking")]
    [Tooltip("The physical location of this checkpoint, to be used by the clue proximity thingy")]
    public float latitude;
    public float longitude;

    [Header("Order of Checkpoints")]
    public Checkpoint next;

    private void Start()
    {


        Debug.Log("Target acquired: " + imageName + ", " + latitude.ToString() + ", " + longitude.ToString());
        // TODO: Hook this up to the script that manages the hot/cold distance from clue thingy @Sean :) 

        //Events.Emitter.SendClueLocation(new Vector2(latitude, longitude));
    }

    private void Update()
    {
        if (imageVisible)
        {
            displayObj.transform.position = imagePosition;
            displayObj.SetActive(true);
        }
        else if (displayObj.activeSelf == true)
        {
            displayObj.SetActive(false);
        }
    }

    public void MoveToNextCheckpoint()
    {
        Debug.Log("Move to next checkpoint");
        displayObj.SetActive(false);

        if (next != null)
        {
            next.gameObject.SetActive(true);
        }

        this.gameObject.SetActive(false); // maybe we want to leave old clues up in case people need to go back?
    }

}
