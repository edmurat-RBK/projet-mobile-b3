﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorldManager : MonoBehaviour
{
    public int dummyInstanciate;
    public int bumperInstanciate;
    public int minerInstanciate;

    [Space(10)]

    public Transform otherWorld;

    [Space(10)]

    public List<GameObject> dummyStored = new List<GameObject>();
    public List<GameObject> bumpedStored = new List<GameObject>();
    public List<GameObject> minerStored = new List<GameObject>();

    [Space(10)]

    public GameObject dummyPrefab;
    public GameObject bumperPrefab;
    public GameObject minerPrefab;
}
