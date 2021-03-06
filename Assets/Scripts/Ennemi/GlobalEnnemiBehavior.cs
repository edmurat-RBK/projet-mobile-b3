using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnnemiBehavior : MonoBehaviour
{
    public int ennemiLife;
    public float speedMultiplicator = 1f;

    public bool isAlive = true;

    private void Start()
    {
        EnnemiManager.EMInstance.ennemiList.Add(this.gameObject);
    }




    public void MoveBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), 200/speedMultiplicator * Time.deltaTime);
    }

    public void Death()
    {
        EnnemiManager.EMInstance.ennemiList.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
