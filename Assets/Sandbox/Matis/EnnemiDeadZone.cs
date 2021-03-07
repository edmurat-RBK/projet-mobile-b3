using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiDeadZone : MonoBehaviour
{
    private void Start()
    {
        EnnemiManager.EMInstance.deadZone = this.transform;
    }
}
