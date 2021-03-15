using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Matis Duperray
/// Gère l'apparition des ennemies dans le jeu | Gère également le nombre d'ennemi max à l'écran
/// </summary>
public class WaveManager : MonoBehaviour
{
    public List<Transform> spawnPointList = new List<Transform>();

    public int maxEnnemiInLevel;
    public float timeBetweenSpawn = 1f;

    public GameObject dummyPrefab;


    private bool canSpawn = true;




    private void Update()
    {
        CreateNewWave();
    }

    //Instancie les ennemis
    void CreateNewWave()
    {

        if (EnnemiManager.EMInstance.ennemiList.Count < maxEnnemiInLevel)//Tant que la liste d'ennemi active n'est pas pleine...
        {

            for (int i = 0; i < (maxEnnemiInLevel - EnnemiManager.EMInstance.ennemiList.Count); i++)
            {
                int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


                if (canSpawn)
                {
                    GameObject Dummy = Instantiate(dummyPrefab, spawnPointList[index].position, spawnPointList[index].rotation);
                    //...on fait spawn un ennemi qui se range tout seul dans la List.

                    StartCoroutine(SpawnCoolDown());
                }


            }
        }

    }

    IEnumerator SpawnCoolDown()
    {
        canSpawn = false;
        timeBetweenSpawn = Random.Range(2, 10);
        yield return new WaitForSeconds(timeBetweenSpawn);
        canSpawn = true;
    }
}
