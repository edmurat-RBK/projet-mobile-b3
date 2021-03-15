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
        GameManager.Instance.ennemiManager.ennemiList.Add(this.gameObject);
    }




    public void MoveBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), TerrainManager.TMInstance.scrollSpeed/speedMultiplicator * Time.deltaTime);
    }

    public void Death()
    {
        GameManager.Instance.ennemiManager.ennemiList.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
