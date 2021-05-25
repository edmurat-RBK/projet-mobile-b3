using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            GameManager[] managers = FindObjectsOfType(typeof(GameManager)) as GameManager[];
            if (managers.Length == 0)
            {
                Debug.LogWarning("GameManager not present on the scene. Creating a new one.");
                GameManager manager = new GameObject("Game Manager").AddComponent<GameManager>();
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
                Debug.LogError("You can only use one GameManager. Destroying the new one attached to the GameObject " + value.gameObject.name);
                Destroy(value);
            }
        }
    }
    private static GameManager _instance = null;
    #endregion
    private void Awake() {
        questManager = FindObjectOfType<QuestManager>();
        
    }

    public PlayerManager playerManager;
    public EconomicManager economicManager;
    public EnnemiManager ennemiManager;
    public WaveManager waveManager;
    public TerrainManager terrainManager;
    public InputManager inputManager;
    public OtherWorldManager otherWorldManager;
    public HighScore highScoreManager;
    public QuestManager questManager;
    public ShopManager shopManager;
}
