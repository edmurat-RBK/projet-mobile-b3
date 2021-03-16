using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperBehavior : GlobalEnnemiBehavior
{
    private void Start()
    {
        GameManager.Instance.ennemiManager.ennemiList.Add(this.gameObject);
    }
    private void Update()
    {
        CheckDirection();
        CheckForPlayer();
        Movement();
        MoveBack(true);


        if (ennemiLife <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Death();
        }
    }
}
