using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public Transform deadZone;
    public List<GameObject> ennemiList = new List<GameObject>();



    [Space(20)]

    #region Dummy
    [Header("Dummy")]

    public int dummyLife;
    #endregion

    [Space(20)]

    #region Bumper
    [Header("Bumper")]

    public int bumperLife;
    [Space(5)]
    public float arrestSideOfPlayerDuration;
    [Space(5)]
    public float bumperAttackSpeed;
    public float bumperAttackDuration;
    public float bumperAttackCoolDown;
    #endregion
}
