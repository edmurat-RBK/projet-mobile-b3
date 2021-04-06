// Edouard MURAT

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TerrainManager : MonoBehaviour
{
    #region Singleton
    public static TerrainManager TMInstance;
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
    


    private void Start()
    {
        terrainQueue = new Queue<GameObject>();
        worldParentObject = GameObject.Find("----- WORLD -----");
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
        boostRef.boostCharges -= 1;
        scrollSpeed = boostSpeed;
        boostRef.isBoosting = true;
        Invoke("EndBoost", duration);
    }
    
    void EndBoost()
    {
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

    private void AddTerrain(string tag, Vector3 position)
    {
        GameObject newInstance = ObjectPooler.Instance.SpawnFromPool(tag, position, Quaternion.identity);
        terrainQueue.Enqueue(newInstance);
    }
}
