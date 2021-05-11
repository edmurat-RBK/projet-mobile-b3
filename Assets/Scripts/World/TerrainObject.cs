// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTerrain", menuName = "Scriptable Objects/TerrainObject", order = 1)]
public class TerrainObject : ScriptableObject
{
    public string tag;
    public GameObject terrainObject;
}
