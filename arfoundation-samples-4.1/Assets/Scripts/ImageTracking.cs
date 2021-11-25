using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// https://youtu.be/I9j3MD7gS5Y

[RequireComponent(typeof(ARTrackedImageManager))]

public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager trackedImageManager;
    private Checkpoint[] checkpoints;
    private Dictionary<string, Checkpoint> imageToCheckpoint;

    private void Awake()
    {
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>();
        checkpoints = FindObjectsOfType<Checkpoint>(true);
        imageToCheckpoint = new Dictionary<string, Checkpoint>();

        foreach (Checkpoint c in checkpoints)
        {
            Debug.Log("Adding to checkpoint dictionary: " + c.imageName);
            imageToCheckpoint[c.imageName] = c;
        }

    }

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += ImageChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventsArgs)
    {
        foreach (ARTrackedImage trackedImage in eventsArgs.added)
        {
            UpdateImage(trackedImage);
        }

        foreach (ARTrackedImage trackedImage in eventsArgs.updated)
        {
            UpdateImage(trackedImage);
        }

    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        Vector3 position = trackedImage.transform.position;



        if (imageToCheckpoint.ContainsKey(name))
        {
            Checkpoint checkpoint = imageToCheckpoint[name];

            if (checkpoint.isActiveAndEnabled == true)
            {
                checkpoint.imageVisible = trackedImage.trackingState == TrackingState.Tracking;
                checkpoint.imagePosition = position;
            }

        }

    }
}
