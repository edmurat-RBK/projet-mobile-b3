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


    private bool canSpawn = true;




    private void Update()
    {
        CreateNewWave();
    }

    //Instancie les ennemis
    void CreateNewWave()
    {

        if (GameManager.Instance.ennemiManager.ennemiList.Count < maxEnnemiInLevel)//Tant que la liste d'ennemi active n'est pas pleine...
        {

            for (int i = 0; i < (maxEnnemiInLevel - GameManager.Instance.ennemiManager.ennemiList.Count); i++)
            {
                int index = Random.Range(1, 3);
                if(index == 1)
                {
                    SpawnDummy();
                }
                else
                {
                    SpawnBumper();
                }
            }
        }

    }



    void SpawnDummy()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            GameManager.Instance.otherWorldManager.dummyStored[0].transform.position = spawnPointList[index].transform.position;
            GameManager.Instance.ennemiManager.ennemiList.Add(GameManager.Instance.otherWorldManager.dummyStored[0]);
            GameManager.Instance.otherWorldManager.dummyStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            GameManager.Instance.otherWorldManager.dummyStored.RemoveAt(0);
            //...on fait spawn un ennemi qui se range tout seul dans la List.

            StartCoroutine(SpawnCoolDown());
        }
    }
    void SpawnBumper()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            GameManager.Instance.otherWorldManager.bumpedStored[0].transform.position = spawnPointList[index].transform.position;
            GameManager.Instance.ennemiManager.ennemiList.Add(GameManager.Instance.otherWorldManager.bumpedStored[0]);
            GameManager.Instance.otherWorldManager.bumpedStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            GameManager.Instance.otherWorldManager.bumpedStored.RemoveAt(0);
            //...on fait spawn un ennemi qui se range tout seul dans la List.

            StartCoroutine(SpawnCoolDown());
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
