
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class InputManager : MonoBehaviour
{
    private TouchController touchController;

    public static Action<Vector2> OnStartTouch;
    public static Action<Vector2> OnEndTouch;

    private void Awake()
    {
        touchController = new TouchController();
    }

    private void OnEnable()
    {
        touchController.Enable();
    }

    private void OnDisable()
    {
        touchController.Disable();
    }
    private void Start()
    {
        touchController.Touch.TouchPress.started += ctx => StartTouch(ctx);
        touchController.Touch.TouchPress.canceled += ctx => EndTouch(ctx);
        
    }

    void StartTouch(InputAction.CallbackContext context)
    {
        OnStartTouch?.Invoke(touchController.Touch.TouchPosition.ReadValue<Vector2>());
    }
    void EndTouch(InputAction.CallbackContext context)
    {
        OnEndTouch?.Invoke(touchController.Touch.TouchPosition.ReadValue<Vector2>());
    }
}
