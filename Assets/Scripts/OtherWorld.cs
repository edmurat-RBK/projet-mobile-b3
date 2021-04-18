using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorld : MonoBehaviour
{
    private OtherWorldManager otherWorldManager;

    private void Awake() {
        otherWorldManager = GameManager.Instance.otherWorldManager;
    }

    private void Start()
    {
        otherWorldManager.otherWorld = this.transform;


        int index = otherWorldManager.dummyInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Dummy = Instantiate(otherWorldManager.dummyPrefab, transform.position, transform.rotation);
            otherWorldManager.dummyStored.Add(Dummy);
            Dummy.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = otherWorldManager.bumperInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Bumper = Instantiate(otherWorldManager.bumperPrefab, transform.position, transform.rotation);
            otherWorldManager.bumpedStored.Add(Bumper);
            Bumper.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = otherWorldManager.minerInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Miner = Instantiate(otherWorldManager.minerPrefab, transform.position, transform.rotation);
            otherWorldManager.minerStored.Add(Miner);
            Miner.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = otherWorldManager.golderInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Golder = Instantiate(otherWorldManager.golderPrefab, transform.position, transform.rotation);
            otherWorldManager.golderStored.Add(Golder);
            Golder.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = otherWorldManager.flamerInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Flamer = Instantiate(otherWorldManager.flamerPrefab, transform.position, transform.rotation);
            otherWorldManager.flamerStored.Add(Flamer);
            Flamer.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }
    }
}
