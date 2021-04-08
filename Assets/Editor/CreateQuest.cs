using UnityEngine;
using UnityEditor;
using System.IO;

public class CreateQuest : EditorWindow
{
    const string questFolder = "Assets/Quests/";
    string questName = "";
    bool destroyObjects = false;
    int objectsToDestroy = 0;
    bool killEnemies = false;
    int enemiesToKill = 0;
    bool pickupCoins = false;
    int coinsToPickup = 0;
    bool reachScore = false;
    int scoreToReach = 0;

    [MenuItem("Tools/QuestMaker")]
    public static void ShowWindow()
    {
        GetWindow(typeof(CreateQuest));
    }

    private void OnGUI() 
    {
        GUILayout.Label("Create Quest", EditorStyles.boldLabel);

        questName = EditorGUILayout.TextField("Quest Name", questName);
        destroyObjects = EditorGUILayout.Toggle("Destroy Objects", destroyObjects);
        if (destroyObjects)
        {
           objectsToDestroy = EditorGUILayout.IntField("Objects To Destroy",objectsToDestroy);
        }

        killEnemies = EditorGUILayout.Toggle("Kill Enemies", killEnemies);
        if (killEnemies)
        {
           enemiesToKill = EditorGUILayout.IntField("Enemies To Kill",enemiesToKill);
        }

        pickupCoins = EditorGUILayout.Toggle("Pick Up Coins", pickupCoins);
        if (pickupCoins)
        {
           coinsToPickup = EditorGUILayout.IntField("Coins To Pick Up",coinsToPickup);
        }

        reachScore = EditorGUILayout.Toggle("Reach Score", reachScore);
        if (reachScore)
        {
           scoreToReach = EditorGUILayout.IntField("Score To Reach",scoreToReach);
        }

        if (!string.IsNullOrWhiteSpace(questName) && GUILayout.Button("Create Quest"))
        {
            QuestCreation();
        }
        else if (string.IsNullOrWhiteSpace(questName))
        {
            EditorGUILayout.HelpBox("Quest Name cannot be null", MessageType.Error);
        }
    }

    private void QuestCreation()
    {

        Quests quest = ScriptableObject.CreateInstance<Quests>();
        string path = AssetDatabase.GenerateUniqueAssetPath(Path.Combine(questFolder, $"{questName}.asset"));
        
        quest.questname = questName;
        quest.destroyObjects = destroyObjects;
        quest.objectsToDestroy = objectsToDestroy;
        quest.killEnemies = killEnemies;
        quest.enemiesToKill = enemiesToKill;
        quest.pickupCoins = pickupCoins;
        quest.coinsToPickup = coinsToPickup;
        quest.reachScore = reachScore;
        quest.scoreToReach = scoreToReach;

        AssetDatabase.CreateAsset(quest,path);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = quest;
    }
}
