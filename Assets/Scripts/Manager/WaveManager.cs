﻿using System.Collections;
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

    EnnemiManager ennemiManager;
    OtherWorldManager otherWorldManager;

    private void Start()
    {
        ennemiManager = GameManager.Instance.ennemiManager;
        otherWorldManager = GameManager.Instance.otherWorldManager;
    }
    private void Update()
    {
        CreateNewWave();
    }

    //Instancie les ennemis
    void CreateNewWave()
    {

        if (ennemiManager.ennemiList.Count < maxEnnemiInLevel)//Tant que la liste d'ennemi active n'est pas pleine...
        {

            for (int i = 0; i < (maxEnnemiInLevel - ennemiManager.ennemiList.Count); i++)
            {
                int index = Random.Range(1, 6);

                switch(index)
                {
                    case (1):
                        SpawnDummy();
                        break;

                    case (2):
                        SpawnBumper();
                        break;

                    case (3):
                        SpawnMiner();
                        break;

                    case (4):
                        SpawnGolder();
                        break;

                    case (5):
                        SpawnFlamer();
                        break;

                    default:
                        SpawnDummy();
                        break;
                }
            }
        }

    }



    void SpawnDummy()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            otherWorldManager.dummyStored[0].SetActive(true);

            otherWorldManager.dummyStored[0].transform.position = spawnPointList[index].transform.position;
            ennemiManager.ennemiList.Add(otherWorldManager.dummyStored[0]);
            otherWorldManager.dummyStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            otherWorldManager.dummyStored.RemoveAt(0);
            //...on fait spawn un ennemi qui se range tout seul dans la List.

            StartCoroutine(SpawnCoolDown());
        }
    }
    void SpawnBumper()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            otherWorldManager.bumpedStored[0].SetActive(true);

            otherWorldManager.bumpedStored[0].transform.position = spawnPointList[index].transform.position;
            ennemiManager.ennemiList.Add(otherWorldManager.bumpedStored[0]);
            otherWorldManager.bumpedStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            otherWorldManager.bumpedStored.RemoveAt(0);
            //...on fait spawn un ennemi qui se range tout seul dans la List.

            StartCoroutine(SpawnCoolDown());
        }
    }
    void SpawnMiner()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            otherWorldManager.minerStored[0].SetActive(true);

            otherWorldManager.minerStored[0].transform.position = spawnPointList[index].transform.position;
            ennemiManager.ennemiList.Add(otherWorldManager.minerStored[0]);
            otherWorldManager.minerStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            otherWorldManager.minerStored.RemoveAt(0);
            //...on fait spawn un ennemi qui se range tout seul dans la List.

            StartCoroutine(SpawnCoolDown());
        }
    }
    void SpawnGolder()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            otherWorldManager.golderStored[0].SetActive(true);

            otherWorldManager.golderStored[0].transform.position = spawnPointList[index].transform.position;
            ennemiManager.ennemiList.Add(otherWorldManager.golderStored[0]);
            otherWorldManager.golderStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            otherWorldManager.golderStored.RemoveAt(0);
            //...on fait spawn un ennemi qui se range tout seul dans la List.

            StartCoroutine(SpawnCoolDown());
        }
    }

    void SpawnFlamer()
    {
        int index = Random.Range(0, spawnPointList.Count);//On tire un point de spawn random


        if (canSpawn)
        {
            otherWorldManager.flamerStored[0].SetActive(true);

            otherWorldManager.flamerStored[0].transform.position = spawnPointList[index].transform.position;
            ennemiManager.ennemiList.Add(otherWorldManager.flamerStored[0]);
            otherWorldManager.flamerStored[0].GetComponent<GlobalEnnemiBehavior>().isAlive = true;
            otherWorldManager.flamerStored.RemoveAt(0);
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
