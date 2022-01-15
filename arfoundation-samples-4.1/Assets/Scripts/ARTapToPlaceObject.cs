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
    public GameObject ARCamera;

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
            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                //gameObjectToInstantiate.SetActive(true);
                //spawnedObject = Instantiate(gameObjectToInstantiate, hitPose.position, hitPose.rotation);
                Debug.Log("gameObject set Active");
                
                gameObjectToInstantiate.transform.position = hitPose.position;
                gameObjectToInstantiate.transform.rotation = hitPose.rotation;

                Vector3 cameraPosition = ARCamera.transform.position;
                cameraPosition.y = hitPose.position.y;
                gameObjectToInstantiate.transform.LookAt(cameraPosition, gameObjectToInstantiate.transform.up);
               gameObjectToInstantiate.SetActive(true);
            }
            else
            {
                //if there's object already, then can move around
                gameObjectToInstantiate.transform.position = hitPose.position;
            }
        }
    }
}
