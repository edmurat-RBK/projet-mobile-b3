using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehavior : GlobalEnnemiBehavior
{





    private void Start()
    {
        GameManager.Instance.ennemiManager.ennemiList.Add(this.gameObject);
    }
    private void Update()
    {
        #region Debug
        Debug.DrawRay(transform.position, transform.forward*50, Color.red);
        Debug.DrawRay(transform.position, (transform.forward + transform.right/2)*50, Color.red);
        Debug.DrawRay(transform.position, (transform.forward - transform.right/2)*50, Color.red);
        Debug.DrawRay(transform.position, transform.right*20, Color.blue);
        Debug.DrawRay(transform.position, -transform.right*20, Color.blue);
        #endregion


        CheckDirection();
        Movement();
        MoveBack();


        if(ennemiLife <= 0 || transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Death();
        }
    }
}
