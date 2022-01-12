using System;
using UnityEngine;

public class TouchDetection : MonoBehaviour
{
    public Camera cam;

    [SerializeField] private float maxDist = 0f;
    [SerializeField] private float maxTime = 1f;

    public float interactionDistance = 100f;

    private InputManager inputManager;

    private Vector2 startPos;
    private float startTime;

    private Vector2 endPos;
    private float endTime;

    private int layerMask;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        layerMask = LayerMask.GetMask("Interactable");
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += TouchStart;
        inputManager.OnEndTouch += TouchEnd;
        
    }

    private void TouchStart(Vector2 pos, float time)
    {
        startPos = pos;
        startTime = time;
    }

    private void TouchEnd(Vector2 pos, float time)
    {
        endPos = pos;
        endTime = time;
        DetectTouch();
    }

    private void DetectTouch()
    {
        if (Vector2.Distance(startPos, endPos) <= maxDist &&
            (endTime-startTime <=maxTime))
        {
            Debug.Log("Touch Detected!");

            Ray ray = Camera.main.ScreenPointToRay(endPos);
            RaycastHit hitInfo;
            var hit = Physics.Raycast(ray, out hitInfo, maxDistance: interactionDistance);
            if (hit)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    Debug.Log("Touch Interactable object hit!");
                    interactable.OnTouch();
                }
            }
        }
    }
}
