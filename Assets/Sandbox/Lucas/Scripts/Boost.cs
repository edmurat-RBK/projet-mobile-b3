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
    public Vector2 firstPos;
    public Vector2 secondPos;
    public TerrainManager terrainManager;
    public void OnBoost()
    {
        Debug.Log("onboost");
        bool callOnce;
        callOnce = true;

        if (!clickDown && callOnce)
        {
            firstPos = Mouse.current.position.ReadValue();
            callOnce = false;
        }
        if (clickDown && callOnce)
        {
            secondPos = Mouse.current.position.ReadValue();
            callOnce = false;
            Invoke("ResetPos", .5f);
        }
        clickDown = !clickDown;
        
    }
    void ResetPos()
    {
        firstPos = Vector2.zero;
        secondPos = Vector2.zero;
    }
    private void Update()
    {
        if (firstPos != Vector2.zero && secondPos != Vector2.zero)
        {
            if (secondPos.y > firstPos.y + SwipeLength)
            {
                
                terrainManager.Boost(boostDuration);
                ResetPos();
                

            }
        }
    }
}
