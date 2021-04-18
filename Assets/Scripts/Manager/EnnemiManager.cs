using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public GameObject deathFX;
    public Transform deadZone;
    public List<GameObject> ennemiList = new List<GameObject>();



    [Space(20)]

    #region Dummy
    [Header("Dummy")]

    public int dummyLife;
    public int dummyLoot;
    #endregion

    [Space(20)]

    #region Bumper
    [Header("Bumper")]

    public int bumperLife;
    public int bumperLoot;
    [Space(5)]
    public float arrestSideOfPlayerDuration;
    [Space(5)]
    public float bumperAttackSpeed;
    public float bumperAttackDuration;
    public float bumperAttackCoolDown;
    #endregion

    [Space(20)]

    #region Miner
    [Header("Miner")]

    public int minerLife;
    public int minerLoot;
    [Space(5)]
    public float minerArrestSideOfPlayerDuration;
    public float stopDuration;
    [Space(5)]
    public float minerDropRate;
    public float xPosForDrop;
    [Space(5)]
    public int mineDamage;
    #endregion

    [Space(20)]

    #region Golder
    [Header("Golder")]

    public int golderLife;
    public int golderLoot;
    [Space(5)]
    public float golderDropRate;
    public float gloderStayDuration;
    #endregion

    [Space(20)]

    #region Flamer
    [Header("Flamer")]

    public int flamerLife;
    public int flamerLoot;
    [Space(5)]
    public float flamerAttackDuration;
    public float flamerWaitSideOfPlayer;
    [Space(5)]
    public float xPosForFire;
    #endregion
}
