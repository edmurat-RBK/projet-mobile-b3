using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnnemiBehavior : MonoBehaviour
{
    public int ennemiLife;
    public float ennemiSpeed;

    public bool isAlive = true;

    private void Start()
    {
        EnnemiManager.EMInstance.ennemiList.Add(this.gameObject);
    }



    public void Death()
    {
        EnnemiManager.EMInstance.ennemiList.Remove(this.gameObject);
        Destroy(gameObject);
    }
}
