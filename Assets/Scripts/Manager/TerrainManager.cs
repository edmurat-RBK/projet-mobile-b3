// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainManager : MonoBehaviour
{
    #region Singleton
    public static TerrainManager TMInstance;
    public List<TerrainObject> terrainPool;
    public TerrainObject shopTerrain;
    public int distanceBewteenShop;
    private int nextShop;
    public int distanceVariation;
    public float terrainLenght;
    public float scrollSpeed;
    public float boostSpeed;
    [HideInInspector]
    public float baseScrollspeed;
    public int terrainCount;
    private Queue<GameObject> terrainQueue;
    private GameObject worldParentObject;
    Boost boostRef;

    PlayerManager playerManager;

    [Header("Audio")]
    AK.Wwise.RTPC localMotorRTCP;
    int motorVar = 0;
    
    
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
        nextShop = distanceBewteenShop + Random.Range(-distanceVariation,distanceVariation);
        for(int i = 0; i<terrainCount; i++)
        {
            if(i==0) {
                AddTerrain("LD_Start", new Vector3(0, 0, terrainLenght*i));
            }
            else if(nextShop <= 0) {
                AddTerrain(shopTerrain.tag, new Vector3(0, 0, terrainLenght*i));
                nextShop = distanceBewteenShop + Random.Range(-distanceVariation,distanceVariation);
            }
            else {
                AddTerrain(terrainPool[Random.Range(1,terrainPool.Count)].tag, new Vector3(0, 0, terrainLenght*i));
            }

            nextShop--;
        }

        playerManager = GameManager.Instance.playerManager;

        localMotorRTCP = AudioManager.AMInstance.motorVarRTPC;
    }

    private void Update()
    {
        try
        {
            if(!ShopManager.Instance.shopActive) {
                MoveAllTerrains();
            }
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
                GameObject dequeuedInstance = terrainQueue.Dequeue();
                dequeuedInstance.SetActive(false);
                GameObject[] gameObjectArray = terrainQueue.ToArray();
                Vector3 newPosition = gameObjectArray[gameObjectArray.Length-1].transform.position;
                if(nextShop <= 0) {
                    AddTerrain(shopTerrain.tag, new Vector3(0, 0, newPosition.z + terrainLenght));
                    nextShop = distanceBewteenShop + Random.Range(-distanceVariation,distanceVariation);
                }
                else {
                    AddTerrain(terrainPool[Random.Range(1,terrainPool.Count)].tag, new Vector3(0, 0, newPosition.z + terrainLenght));
                    nextShop--;
                }

            }
        }
    }

    public void Boost(float duration)
    {
        playerManager.playerIsBoosting = true;
        playerManager.player.GetComponent<PlayerController>().animator.SetTrigger("isBoosting");
        boostRef.boostCharges -= 1;
        scrollSpeed = boostSpeed;
        boostRef.isBoosting = true;
        boostRef.isCoolingDown = false;

        motorVar += 100;
        localMotorRTCP.SetGlobalValue(motorVar);


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
        newInstance.SetActive(true);
    }
}
