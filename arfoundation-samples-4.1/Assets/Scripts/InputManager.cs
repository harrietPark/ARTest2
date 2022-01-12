using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    private TouchControl touchControl;

    private void Awake()
    {
        touchControl = new TouchControl();
    }

    private void OnEnable()
    {
        touchControl.Enable();

        touchControl.Touch.TouchInput.started += StartTouchPrimary;
        touchControl.Touch.TouchInput.canceled += EndTouchPrimary;
    }

    private void OnDisable()
    {
        touchControl.Disable();

        touchControl.Touch.TouchInput.started -= StartTouchPrimary;
        touchControl.Touch.TouchInput.canceled -= EndTouchPrimary;
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
        {
            OnStartTouch(touchControl.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.startTime);
        }
    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(touchControl.Touch.TouchPosition.ReadValue<Vector2>(), (float)context.time);
        }
    }
}
