using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTerrain : MonoBehaviour, IPooledObject
{
    public void OnObjectSpawn()
    {
        Debug.Log($"{gameObject.name} has spawned from its pool");
    }
}
