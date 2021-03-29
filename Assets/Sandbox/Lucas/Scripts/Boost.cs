using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
/// <summary>
/// Lucas DEUTSCHMANN
/// Player Controller
/// </summary>
[RequireComponent(typeof(PlayerInput))]

public class Boost : MonoBehaviour
{
    public float boostDuration;
    public float boostCooldown;
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
    [HideInInspector]
    public bool isCoolingDown;
    public Slider slider;
    public int boostCharges;
    public int maxBoostCharges = 3;
    
    

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
        if (boostCharges > 0)
        {
           if (firstPos != Vector2.zero && secondPos != Vector2.zero)
            {
                if (secondPos.y > firstPos.y + SwipeLength  && !isCoolingDown && !isBoosting)
                {
                    TerrainManager.TMInstance.Boost(boostDuration);
                
                    ResetPos();
                }
            }
            if (firstPos2 != Vector2.zero && secondPos2 != Vector2.zero)
            {
                if (secondPos2.y > firstPos2.y + SwipeLength && !isCoolingDown && !isBoosting)
                {
                    TerrainManager.TMInstance.Boost(boostDuration);
                
                    ResetPos2();
                }
            } 
        }
        

        if (isBoosting)
        {
            slider.value -= 1/boostDuration * Time.deltaTime;
        }

        if (isCoolingDown)
        {
            slider.value += 1/boostCooldown * Time.deltaTime;
        }
    }
    private void Start() {
        boostCharges = maxBoostCharges;
    }
}
