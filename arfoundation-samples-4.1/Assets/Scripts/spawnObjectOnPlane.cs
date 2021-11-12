using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class spawnObjectOnPlane : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    [SerializeField]
    private GameObject placeablePrefab;

    static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    //where the user is pressing on the screen
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        //valid touch
        if (Input.touchCount > 0)
        {
            //store the first touch that is received 
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else
        {
            touchPosition = default;
            return false;
        }
       
    }

    private void Update()
    {
        //check if user is touching the position
        //if not, return
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        //if user is touching somewhere on the screen,
        //check whether it's hitting a trackable plane 
        if (raycastManager.Raycast(touchPosition, s_hits, TrackableType.PlaneWithinPolygon))
        {
            //first index 
            var hitPos = s_hits[0].pose;
            //check if we already have spawnedObject in the world
            //if don't have -> Instantiate spawnedObject
            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(placeablePrefab, hitPos.position, hitPos.rotation);
            }
            //if we already have a spawnedObject, update it's transform
            else
            {
                spawnedObject.transform.position = hitPos.position;
                spawnedObject.transform.rotation = hitPos.rotation;
            }
        }
    }
}
