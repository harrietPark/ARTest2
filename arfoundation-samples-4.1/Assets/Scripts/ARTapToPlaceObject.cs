using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlaceObject : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    private GameObject spawnedObject;
    private ARRaycastManager arRaycastManager;
    private Vector2 touchPos; //where we tap on the screen

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    private bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(index: 0).position;
            Debug.Log("is touched");
            return true;
        }
        else
        {
            touchPos = default;
            return false;
        }
        
    }
    
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPos))
        {
            Debug.Log("no touch detected");
            return;
        }
        if (arRaycastManager.Raycast(touchPos, hits, TrackableType.PlaneWithinPolygon))
        {
            //var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                gameObjectToInstantiate.SetActive(true);
                Debug.Log("gameObject set Active");
            }
            //else
            //{
                //if there's object already, then can move around
               // spawnedObject.transform.position = hitPose.position;
            //}
        }
    }
}
