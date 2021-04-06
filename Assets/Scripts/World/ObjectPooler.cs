using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    #region Singleton
    public static ObjectPooler Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            ObjectPooler[] managers = FindObjectsOfType(typeof(ObjectPooler)) as ObjectPooler[];
            if (managers.Length == 0)
            {
                Debug.LogWarning("ObjectPooler not present on the scene. Creating a new one.");
                ObjectPooler manager = new GameObject("Object Pooler").AddComponent<ObjectPooler>();
                _instance = manager;
                return _instance;
            }
            else
            {
                return managers[0];
            }
        }
        set
        {
            if (_instance == null)
                _instance = value;
            else
            {
                Debug.LogError("You can only use one ObjectPooler. Destroying the new one attached to the GameObject " + value.gameObject.name);
                Destroy(value);
            }
        }
    }
    private static ObjectPooler _instance = null;
    #endregion

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
        public Transform parentInInspector;
    }

    public Dictionary<string, Queue<GameObject>> poolDictionary;
    public List<Pool> poolList;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in poolList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i = 0; i<pool.size; i++)
            {
                GameObject inst = Instantiate(pool.prefab,new Vector3(1000,0,1000),Quaternion.identity, pool.parentInInspector);
                inst.SetActive(false);
                objectPool.Enqueue(inst);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        GameObject spawnedObject = poolDictionary[tag].Dequeue();
        
        spawnedObject.SetActive(true);
        spawnedObject.transform.position = position;
        spawnedObject.transform.rotation = rotation;

        IPooledObject pooledObj = spawnedObject.GetComponent<IPooledObject>();
        if(pooledObj != null)
        {
            pooledObj.OnObjectSpawn();
        }

        poolDictionary[tag].Enqueue(spawnedObject);

        return spawnedObject;
    }
}
