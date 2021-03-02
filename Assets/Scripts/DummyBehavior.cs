using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyBehavior : GlobalEnnemiBehavior
{





    private void Start()
    {
        EnnemiManager.EMInstance.ennemiList.Add(this.gameObject);
    }
    private void Update()
    {
        if(ennemiLife <= 0)
        {
            Death();
        }
    }
}
