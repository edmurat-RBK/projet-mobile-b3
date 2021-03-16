using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
/// <summary>
/// Lucas DEUTSCHMANN
/// Player Controller
/// </summary>
[RequireComponent(typeof(PlayerInput))]

public class Boost : MonoBehaviour
{
    public float boostDuration;
    public int SwipeLength;
    public bool clickDown;
    public bool callOnce = true;
    public bool callOnce2 = true;
    public Vector2 firstPos;
    public Vector2 secondPos;
    public Vector2 firstPos2;
    public Vector2 secondPos2;
    [HideInInspector]
    public bool isBoosting;

    private void OnEnable()
    {
        InputManager.OnStartTouch1 += useBoost;
        InputManager.OnEndTouch1 += useBoost;
        InputManager.OnStartTouch2 += useBoost2;
        InputManager.OnEndTouch2 += useBoost2;
    }
    private void OnDisable()
    {
        InputManager.OnStartTouch1 -= useBoost;
        InputManager.OnEndTouch1 -= useBoost;
        InputManager.OnStartTouch2 -= useBoost2;
        InputManager.OnEndTouch2 -= useBoost2;
    }


    void useBoost(Vector2 position)
    {
        
        if (callOnce)
        {
            firstPos = position;
            callOnce = !callOnce;
        }
        else if (!callOnce)
        {
            secondPos = position;
            callOnce = !callOnce;
            Invoke("ResetPos", .5f);
        }
    }
    void useBoost2(Vector2 position)
    {
        
        if (callOnce2)
        {
            firstPos2 = position;
            callOnce2 = !callOnce2;
        }
        else if (!callOnce2)
        {
            secondPos2 = position;
            callOnce2 = !callOnce2;
            Invoke("ResetPos2", .5f);
        }
    }
    //public void OnBoost()
    //{
    //    bool callOnce;
    //    callOnce = true;

    //    if (!clickDown && callOnce)
    //    {
    //        firstPos = Mouse.current.position.ReadValue();
    //        callOnce = false;
    //    }
    //    if (clickDown && callOnce)
    //    {
    //        secondPos = Mouse.current.position.ReadValue();
    //        callOnce = false;
    //        Invoke("ResetPos", .5f);
    //    }
    //    clickDown = !clickDown;

    //}
    void ResetPos()
    {
        firstPos = Vector2.zero;
        secondPos = Vector2.zero;
        
    }
    void ResetPos2()
    {
        firstPos2 = Vector2.zero;
        secondPos2 = Vector2.zero;
        
    }
    private void Update()
    {
        if (firstPos != Vector2.zero && secondPos != Vector2.zero)
        {
            if (secondPos.y > firstPos.y + SwipeLength)
            {
                TerrainManager.TMInstance.Boost(boostDuration);
                
                ResetPos();
                

            }
        }
        if (firstPos2 != Vector2.zero && secondPos2 != Vector2.zero)
        {
            if (secondPos2.y > firstPos2.y + SwipeLength)
            {
                TerrainManager.TMInstance.Boost(boostDuration);
                
                ResetPos2();
                

            }
        }
    }
}
