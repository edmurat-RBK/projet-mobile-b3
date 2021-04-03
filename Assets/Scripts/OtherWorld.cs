using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherWorld : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.otherWorldManager.otherWorld = this.transform;


        int index = GameManager.Instance.otherWorldManager.dummyInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Dummy = Instantiate(GameManager.Instance.otherWorldManager.dummyPrefab, transform.position, transform.rotation);
            GameManager.Instance.otherWorldManager.dummyStored.Add(Dummy);
            Dummy.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = GameManager.Instance.otherWorldManager.bumperInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Bumper = Instantiate(GameManager.Instance.otherWorldManager.bumperPrefab, transform.position, transform.rotation);
            GameManager.Instance.otherWorldManager.bumpedStored.Add(Bumper);
            Bumper.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = GameManager.Instance.otherWorldManager.minerInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Miner = Instantiate(GameManager.Instance.otherWorldManager.minerPrefab, transform.position, transform.rotation);
            GameManager.Instance.otherWorldManager.minerStored.Add(Miner);
            Miner.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }

        index = GameManager.Instance.otherWorldManager.golderInstanciate;
        for (int i = 0; i < index; i++)
        {
            GameObject Golder = Instantiate(GameManager.Instance.otherWorldManager.golderPrefab, transform.position, transform.rotation);
            GameManager.Instance.otherWorldManager.golderStored.Add(Golder);
            Golder.GetComponent<GlobalEnnemiBehavior>().isAlive = false;
        }
    }
}
