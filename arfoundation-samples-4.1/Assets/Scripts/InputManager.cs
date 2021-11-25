using UnityEngine;
using UnityEngine.InputSystem;

//https://youtu.be/ERAN5KBy2Gs
//https://youtu.be/XUx_QlJpd0M
//https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Touch.html

public class InputManager : MonoBehaviour
{

    public delegate void StartTouch(Vector2 position, float time);
    public event StartTouch OnStartTouch;
    public delegate void EndTouch(Vector2 position, float time);
    public event EndTouch OnEndTouch;

    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();

        playerControls.Player.PrimaryContact.started += StartTouchPrimary;
        playerControls.Player.PrimaryContact.canceled += EndTouchPrimary;

    }

    private void OnDisable()
    {
        playerControls.Disable();

        playerControls.Player.PrimaryContact.started -= StartTouchPrimary;
        playerControls.Player.PrimaryContact.canceled -= EndTouchPrimary;

    }



    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnStartTouch != null)
        {
            OnStartTouch(playerControls.Player.PrimaryPosition.ReadValue<Vector2>(), (float)context.startTime);
        }

    }

    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
        if (OnEndTouch != null)
        {
            OnEndTouch(playerControls.Player.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);
        }

    }
}
