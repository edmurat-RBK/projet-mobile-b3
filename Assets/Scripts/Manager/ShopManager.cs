using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    #region Singleton
    public static ShopManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            ShopManager[] managers = FindObjectsOfType(typeof(ShopManager)) as ShopManager[];
            if (managers.Length == 0)
            {
                Debug.LogWarning("ShopManager not present on the scene. Creating a new one.");
                ShopManager manager = new GameObject("Shop Manager").AddComponent<ShopManager>();
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
                Debug.LogError("You can only use one ShopManager. Destroying the new one attached to the GameObject " + value.gameObject.name);
                Destroy(value);
            }
        }
    }
    private static ShopManager _instance = null;
    #endregion

    public bool shopActive = false;
    public GameObject shopUI;

    private void Start() {
        shopUI.SetActive(false);
    }
}
