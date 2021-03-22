﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorldManager : MonoBehaviour
{
    public int dummyInstanciate;
    public int bumperInstanciate;

    [Space(10)]

    public Transform otherWorld;

    [Space(10)]

    public List<GameObject> dummyStored = new List<GameObject>();
    public List<GameObject> bumpedStored = new List<GameObject>();

    [Space(10)]

    public GameObject dummyPrefab;
    public GameObject bumperPrefab;
}
