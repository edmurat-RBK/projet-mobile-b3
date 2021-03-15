
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class InputManager : MonoBehaviour
{
    private TouchController touchController;

    public static Action<Vector2> OnStartTouch1;
    public static Action<Vector2> OnEndTouch1;
    public static Action<Vector2> OnStartTouch2;
    public static Action<Vector2> OnEndTouch2;

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
        touchController.Touch.TouchPress1.started += ctx => StartTouch1(ctx);
        touchController.Touch.TouchPress1.canceled += ctx => EndTouch1(ctx);
        touchController.Touch.TouchPress2.started += ctx => StartTouch2(ctx);
        touchController.Touch.TouchPress2.canceled += ctx => EndTouch2(ctx);
    }

    void StartTouch1(InputAction.CallbackContext context)
    {
        OnStartTouch1?.Invoke(touchController.Touch.TouchPosition1.ReadValue<Vector2>());
    }
    void EndTouch1(InputAction.CallbackContext context)
    {
        OnEndTouch1?.Invoke(touchController.Touch.TouchPosition1.ReadValue<Vector2>());
    }

    void StartTouch2(InputAction.CallbackContext context)
    {
        OnStartTouch2?.Invoke(touchController.Touch.TouchPosition2.ReadValue<Vector2>());
    }
    void EndTouch2(InputAction.CallbackContext context)
    {
        OnEndTouch2?.Invoke(touchController.Touch.TouchPosition2.ReadValue<Vector2>());
    }
}
