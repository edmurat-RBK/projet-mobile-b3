using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
    public static EnnemiManager EMInstance;

    public List<GameObject> ennemiList = new List<GameObject>();


    void Awake()
    {
        if (EMInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            EMInstance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
