﻿// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainManager : MonoBehaviour
{
    public static TerrainManager TMInstance;
    public List<TerrainObject> terrainPool;
    public float terrainLenght;
    public float scrollSpeed;
    public float boostSpeed;
    [HideInInspector]
    public float baseScrollspeed;
    public int terrainCount;
    private Queue<GameObject> terrainQueue;
    private GameObject worldParentObject;
    Boost boostRef;
    

    private void Awake()
    {
        if (TMInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            TMInstance = this;
        }
        terrainQueue = new Queue<GameObject>();
        
    }

    private void Start()
    {
        worldParentObject = GameObject.Find("----- WORLD -----");
        boostRef = FindObjectOfType<Boost>();
        baseScrollspeed = scrollSpeed;
        for(int i = 0; i<terrainCount; i++)
        {
            AddTerrain(new Vector3(0, 0, terrainLenght*i));
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

    public void Boost(float duration)
    {
        GameManager.Instance.playerManager.playerIsBoosting = true;

        boostRef.boostCharges -= 1;
        scrollSpeed = boostSpeed;
        boostRef.isBoosting = true;
        Invoke("EndBoost", duration);
    }
    
    void EndBoost()
    {
        GameManager.Instance.playerManager.playerIsBoosting = false;

        scrollSpeed = baseScrollspeed;
        boostRef.isBoosting = false;
        boostRef.isCoolingDown = true;
        Invoke("BoostCooldown", boostRef.boostCooldown);
    }

    void BoostCooldown()
    {
        
        boostRef.boostCharges += 1;
        boostRef.isCoolingDown = false;
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
