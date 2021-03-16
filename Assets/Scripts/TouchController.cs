// GENERATED AUTOMATICALLY FROM 'Assets/Sandbox/Lucas/TouchController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @TouchController : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @TouchController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""TouchController"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""a3057131-d25e-4368-800e-d9e6726d8097"",
            ""actions"": [
                {
                    ""name"": ""TouchPress1"",
                    ""type"": ""Button"",
                    ""id"": ""ae2c892f-1c6f-42d5-95b6-1bfc1ef500d0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""TouchPress2"",
                    ""type"": ""Button"",
                    ""id"": ""67f2e877-0c19-4d7b-bced-90fd65d1c6a5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""TouchPosition1"",
                    ""type"": ""PassThrough"",
                    ""id"": ""3cf8c867-f357-4801-b617-33d65062f33a"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""TouchPosition2"",
                    ""type"": ""PassThrough"",
                    ""id"": ""92f4c7a9-7263-4680-b3f3-13410115eec5"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""86370bd7-500f-4ae2-b52b-e1f8ffcd6880"",
                    ""path"": ""<Touchscreen>/touch0/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""902d4da1-4381-4ad6-b27b-3d9b129175d3"",
                    ""path"": ""<Touchscreen>/touch0/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24bd8e71-8d13-4bff-acf9-58d14fc28b33"",
                    ""path"": ""<Touchscreen>/touch1/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPress2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04901145-bccf-4025-a5ef-f495cedd622e"",
                    ""path"": ""<Touchscreen>/touch1/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TouchPosition2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_TouchPress1 = m_Touch.FindAction("TouchPress1", throwIfNotFound: true);
        m_Touch_TouchPress2 = m_Touch.FindAction("TouchPress2", throwIfNotFound: true);
        m_Touch_TouchPosition1 = m_Touch.FindAction("TouchPosition1", throwIfNotFound: true);
        m_Touch_TouchPosition2 = m_Touch.FindAction("TouchPosition2", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_TouchPress1;
    private readonly InputAction m_Touch_TouchPress2;
    private readonly InputAction m_Touch_TouchPosition1;
    private readonly InputAction m_Touch_TouchPosition2;
    public struct TouchActions
    {
        private @TouchController m_Wrapper;
        public TouchActions(@TouchController wrapper) { m_Wrapper = wrapper; }
        public InputAction @TouchPress1 => m_Wrapper.m_Touch_TouchPress1;
        public InputAction @TouchPress2 => m_Wrapper.m_Touch_TouchPress2;
        public InputAction @TouchPosition1 => m_Wrapper.m_Touch_TouchPosition1;
        public InputAction @TouchPosition2 => m_Wrapper.m_Touch_TouchPosition2;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @TouchPress1.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress1;
                @TouchPress1.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress1;
                @TouchPress1.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress1;
                @TouchPress2.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress2;
                @TouchPress2.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress2;
                @TouchPress2.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPress2;
                @TouchPosition1.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition1;
                @TouchPosition1.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition1;
                @TouchPosition1.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition1;
                @TouchPosition2.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition2;
                @TouchPosition2.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition2;
                @TouchPosition2.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTouchPosition2;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TouchPress1.started += instance.OnTouchPress1;
                @TouchPress1.performed += instance.OnTouchPress1;
                @TouchPress1.canceled += instance.OnTouchPress1;
                @TouchPress2.started += instance.OnTouchPress2;
                @TouchPress2.performed += instance.OnTouchPress2;
                @TouchPress2.canceled += instance.OnTouchPress2;
                @TouchPosition1.started += instance.OnTouchPosition1;
                @TouchPosition1.performed += instance.OnTouchPosition1;
                @TouchPosition1.canceled += instance.OnTouchPosition1;
                @TouchPosition2.started += instance.OnTouchPosition2;
                @TouchPosition2.performed += instance.OnTouchPosition2;
                @TouchPosition2.canceled += instance.OnTouchPosition2;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);
    public interface ITouchActions
    {
        void OnTouchPress1(InputAction.CallbackContext context);
        void OnTouchPress2(InputAction.CallbackContext context);
        void OnTouchPosition1(InputAction.CallbackContext context);
        void OnTouchPosition2(InputAction.CallbackContext context);
    }
}
