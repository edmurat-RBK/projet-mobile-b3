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
    Vector2 firstPos;
    Vector2 secondPos;
    Vector2 firstPos2;
    Vector2 secondPos2;
    [HideInInspector]
    public bool isBoosting;
    // [HideInInspector]
    public bool isCoolingDown;
    public bool Running;
    public Slider slider;
    public int boostCharges;
    public int maxBoostCharges;
    public float currentValue;
    public GameObject FXBoost;
    public GameObject FXVitesse;




    void Start()
    {
        boostCharges = maxBoostCharges;
        slider.maxValue = maxBoostCharges;
        slider.value = slider.maxValue;


    }


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
        if (GameManager.Instance.playerManager.boostUnlocked)
        {
            if (boostCharges > 0)
            {
                if (firstPos != Vector2.zero && secondPos != Vector2.zero)
                {
                    if (secondPos.y > firstPos.y + SwipeLength && !isBoosting)
                    {
                        TerrainManager.TMInstance.Boost(boostDuration);

                        ResetPos();
                    }
                }
                if (firstPos2 != Vector2.zero && secondPos2 != Vector2.zero)
                {
                    if (secondPos2.y > firstPos2.y + SwipeLength && !isBoosting)
                    {
                        TerrainManager.TMInstance.Boost(boostDuration);

                        ResetPos2();
                    }
                }
            }
            currentValue = slider.value;
        }

        //si l'anim se finit, isboosting  = false
        // if (GameManager.Instance.playerManager.player.GetComponent<PlayerController>().animator.GetCurrentAnimatorStateInfo(0).IsName("Anim_Player_Boost")&& GameManager.Instance.playerManager.player.GetComponent<PlayerController>().animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        // {
        //     GameManager.Instance.playerManager.player.GetComponent<PlayerController>().animator.SetBool("isBoosting", false);
        // }

        if (isBoosting)
        {
            FXBoost.SetActive(true);
            FXVitesse.SetActive(false);
            slider.value -= (1 + (currentValue - boostCharges)) / boostDuration * Time.deltaTime;
        }
        else
        {
            FXBoost.SetActive(false);
            FXVitesse.SetActive(true);
        }


        if (isCoolingDown && boostCharges < maxBoostCharges)
        {
            slider.value += 1 / boostCooldown * Time.deltaTime;
        }
    }
}
