// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour
{
    public List<TerrainObject> terrainPool;
    public float terrainLenght;
    public float scrollSpeed;
    public int terrainCount;
    private Queue<GameObject> terrainQueue;
    private GameObject worldParentObject;

    private void Awake()
    {
        terrainQueue = new Queue<GameObject>();
    }

    private void Start()
    {
        worldParentObject = GameObject.Find("----- WORLD -----");

        for(int i = 0; i<terrainCount; i++)
        {
            AddTerrain(new Vector3(0, 0, 200*i));
        }
    }

    private void Update()
    {
        try
        {
            MoveAllTerrains();
        }
        catch
        {
            // Keep going
        }
    }

    private void MoveAllTerrains()
    {
        foreach(GameObject go in terrainQueue)
        {
            go.transform.position = Vector3.MoveTowards(go.transform.position, go.transform.position + Vector3.back*100, scrollSpeed * Time.deltaTime);
            
            if(go.transform.position.z < -terrainLenght)
            {
                RemoveTerrain();
                GameObject[] gameObjectArray = terrainQueue.ToArray();
                Vector3 newPosition = gameObjectArray[gameObjectArray.Length-1].transform.position;
                AddTerrain(new Vector3(0, 0, newPosition.z + terrainLenght));
            }
        }
    }

    public void Boost()
    {
        // TO-DO
        Debug.Log("Boost!");
    }

    private void AddTerrain(Vector3 position)
    {
        GameObject newInstance = Instantiate(terrainPool[Random.Range(0, terrainPool.Count)].terrainObject, position, Quaternion.identity,worldParentObject.transform);
        terrainQueue.Enqueue(newInstance);
    }

    private void RemoveTerrain()
    {
        GameObject removedInstance = terrainQueue.Dequeue();
        Destroy(removedInstance);
    }
}
