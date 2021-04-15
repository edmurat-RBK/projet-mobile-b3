// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainManager : MonoBehaviour
{
    #region Singleton
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
    }
    #endregion
    
    private void Start()
    {
        terrainQueue = new Queue<GameObject>();
        boostRef = FindObjectOfType<Boost>();
        baseScrollspeed = scrollSpeed;
        for(int i = 0; i<terrainCount; i++)
        {
            AddTerrain("LD_Alpha01", new Vector3(0, 0, terrainLenght*i));
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
                terrainQueue.Dequeue();
                GameObject[] gameObjectArray = terrainQueue.ToArray();
                Vector3 newPosition = gameObjectArray[gameObjectArray.Length-1].transform.position;
                AddTerrain("LD_Alpha01", new Vector3(0, 0, newPosition.z + terrainLenght));
            }
        }
    }

    public void Boost(float duration)
    {
        GameManager.Instance.playerManager.playerIsBoosting = true;
        GameManager.Instance.playerManager.player.GetComponent<PlayerController>().animator.SetTrigger("isBoosting");
        boostRef.boostCharges -= 1;
        scrollSpeed = boostSpeed;
        boostRef.isBoosting = true;
        boostRef.isCoolingDown = false;
        
        StopAllCoroutines();
        StartCoroutine(EndBoost(duration));
    }
    
    IEnumerator EndBoost(float duration)
    {
        yield return new WaitForSeconds(duration);
        // boostRef.boostCharges -= 1;
        GameManager.Instance.playerManager.playerIsBoosting = false;
        scrollSpeed = baseScrollspeed;
        boostRef.isBoosting = false;
        
        StartCoroutine(BoostCooldown(boostRef.boostCooldown));
    }

    IEnumerator BoostCooldown(float duration)
    {
        boostRef.isCoolingDown = true;
        yield return new WaitForSeconds(duration);
        if(boostRef.boostCharges<boostRef.maxBoostCharges)
            {
                boostRef.boostCharges += 1;
            }
            
            boostRef.isCoolingDown = false;
        
        StartCoroutine(BoostCooldown(boostRef.boostCooldown));
    }

    private void AddTerrain(string tag, Vector3 position)
    {
        
        GameObject newInstance = ObjectPooler.Instance.SpawnFromPool(tag, position, Quaternion.identity);

        terrainQueue.Enqueue(newInstance);
    }
}
