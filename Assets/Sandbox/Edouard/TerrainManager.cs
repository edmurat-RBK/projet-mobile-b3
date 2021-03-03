// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public List<TerrainObject> terrainPool;
    public float terrainSize;
    public float scrollSpeed;
    private float distanceScroll;
    private Queue<TerrainObject> terrainQueue;

    private void Awake()
    {
        distanceScroll = 0f;
    }

    private void Update()
    {
        distanceScroll += scrollSpeed;
    }
}
