// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public List<TerrainObject> terrainPool;
    public float terrainSize;
    public float scrollSpeed;
    private Queue<GameObject> terrainQueue;

    private void Awake()
    {
        terrainQueue = new Queue<GameObject>();
    }

    private void Start()
    {
        AddTerrain(new Vector3(0, 0, 0));
        AddTerrain(new Vector3(0, 0, 200));
        AddTerrain(new Vector3(0, 0, 400));
    }

    private void Update()
    {
        MoveAllTerrains();
    }

    private void MoveAllTerrains()
    {
        foreach(GameObject go in terrainQueue)
        {
            go.transform.position = Vector3.MoveTowards(go.transform.position, go.transform.position + Vector3.back*100, scrollSpeed * Time.deltaTime);
            
            if(go.transform.position.z < -200f)
            {
                RemoveTerrain();
                GameObject[] gameObjectArray = terrainQueue.ToArray();
                Vector3 newPosition = gameObjectArray[gameObjectArray.Length-1].transform.position;
                AddTerrain(new Vector3(0, 0, newPosition.z + terrainSize));
            }
        }
    }

    private void AddTerrain(Vector3 position)
    {
        GameObject newInstance = terrainPool[Random.Range(0, terrainPool.Count)].terrainObject;
        terrainQueue.Enqueue(newInstance);
        Instantiate(newInstance,position,Quaternion.identity);
    }

    private void RemoveTerrain()
    {
        GameObject removedInstance = terrainQueue.Dequeue();
        Destroy(removedInstance);
    }
}
