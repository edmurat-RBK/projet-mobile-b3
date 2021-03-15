using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Fonctions de base de l'ennemi
public class GlobalEnnemiBehavior : MonoBehaviour
{
    public int ennemiLife;
    public bool isAlive = true;

    public LayerMask obstacleMask;
    public LayerMask playerMask;


    public float speedMultiplicator = 1f;


    RaycastHit hit;

    bool obstacleAhead = false;
    bool obstacleOnRight = false;
    bool obstacleOnLeft = false;





    public void MoveBack()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed/speedMultiplicator * Time.deltaTime);
    }

    public void Death()
    {
        GameManager.Instance.ennemiManager.ennemiList.Remove(this.gameObject);
        Destroy(gameObject);
    }

    public void CheckDirection()
    {
        if(Physics.Raycast(transform.position + Vector3.up * 50f, transform.forward, out hit, 4f, obstacleMask)) //Devant
        {
            obstacleAhead = true;
        }
        else
        {
            obstacleAhead = false;
        }

        if(Physics.Raycast(transform.position + Vector3.up * 50f, transform.forward + transform.right, out hit, 2f, obstacleMask)) //Diagonal Droite
        {
            obstacleOnRight = true;
        }
        else
        {
            obstacleOnRight = false;
        }

        if (Physics.Raycast(transform.position + Vector3.up * 50f, transform.forward - transform.right, out hit, 2f, obstacleMask)) //Diagonal Gauche
        {
            obstacleOnLeft = true;
        }
        else
        {
            obstacleOnLeft = false;
        }




        if (Physics.Raycast(transform.position + Vector3.up * 20f, transform.right, out hit, 1.5f, playerMask)) //Côté droit
        {

        }
        else
        {

        }

        if (Physics.Raycast(transform.position + Vector3.up * 20f, -transform.right, out hit, 1.5f, playerMask)) //Côté gauche
        {

        }
        else
        {

        }
    }
    public void Movement()
    {
        if(obstacleAhead == true)
        {
            if(!obstacleOnRight && !obstacleOnLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right * 100), 100f*Time.deltaTime);
            }
            else if(obstacleOnLeft)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right * 100), 100f * Time.deltaTime);
            }
            else if(obstacleOnRight)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.left * 100), 100f * Time.deltaTime);
            }
        }
    }
}
