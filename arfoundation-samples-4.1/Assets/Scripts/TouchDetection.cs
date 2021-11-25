using UnityEngine;

// https://youtu.be/9tePzyL6dgc
// https://youtu.be/858X6_WHfuw

public class TouchDetection : MonoBehaviour
{

    public Camera cam;

    [SerializeField]
    private float maxDist = 0f;
    [SerializeField]
    private float maxTime = 1f;

    public float interactionDistance = 100f;

    private InputManager inputManager;

    private Vector2 startPos;
    private float startTime;

    private Vector2 endPos;
    private float endTime;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += TouchStart;
        inputManager.OnEndTouch += TouchEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= TouchStart;
        inputManager.OnEndTouch -= TouchEnd;
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
            (endTime - startTime <= maxTime))
        {
            Debug.Log("Touch Detected! " + endPos.ToString());
            Debug.DrawRay(cam.ScreenToWorldPoint(endPos), interactionDistance * Vector3.forward, Color.blue, 5f);

            Ray ray = cam.ScreenPointToRay(endPos);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                {
                    Debug.Log("Interactable object hit!");
                    interactable.OnTouch();
                }
            }

        }
    }

}

