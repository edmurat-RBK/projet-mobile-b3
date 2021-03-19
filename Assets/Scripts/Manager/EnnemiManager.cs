using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public Transform deadZone;
    public List<GameObject> ennemiList = new List<GameObject>();


    [Space(10)]
    [Header("Bumper")]

    public float arrestSideOfPlayerDuration;

    public float bumperAttackSpeed;
    public float bumperAttackDuration;
    public float bumperAttackCoolDown;
}
