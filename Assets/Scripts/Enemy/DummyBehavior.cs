﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Matis Duperray
/// Comportement propre à l'ennemi "Dummy"
/// </summary>
public class DummyBehavior : GlobalEnnemiBehavior
{
    private void Start()
    {
        GameManager.Instance.ennemiManager.ennemiList.Add(this.gameObject);
    }
    private void Update()
    {
        CheckDirection();
        Movement();
        MoveBack(false);


        if(ennemiLife <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Death();
        }
    }
}
