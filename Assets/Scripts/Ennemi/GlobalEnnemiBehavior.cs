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
        #region Debug
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
        Debug.DrawRay(transform.position, (transform.forward + transform.right / 3) * 20, Color.red);
        Debug.DrawRay(transform.position, (transform.forward - transform.right / 3) * 20, Color.red);
        Debug.DrawRay(transform.position + Vector3.up, transform.right * 20, Color.blue);
        Debug.DrawRay(transform.position + Vector3.up, -transform.right * 20, Color.blue);
        #endregion

        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f, obstacleMask)) //Devant
        {
            Debug.Log("MOVE sale chien");
            obstacleAhead = true;
        }
        else
        {
            obstacleAhead = false;
        }

        if(Physics.Raycast(transform.position, (transform.forward + transform.right)/3, out hit, 20f, obstacleMask)) //Diagonal Droite
        {
            obstacleOnRight = true;
        }
        else
        {
            obstacleOnRight = false;
        }

        if (Physics.Raycast(transform.position, (transform.forward - transform.right)/3, out hit, 20f, obstacleMask)) //Diagonal Gauche
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
        if(obstacleAhead == true)   //L'ennemi fait face à un obstacle
        {
            if(!obstacleOnRight && !obstacleOnLeft) //La voie est dégagée des deux côtés
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right), 10f*Time.deltaTime);
            }
            else if(obstacleOnLeft && !obstacleOnRight) //La voie est dégagée sur la droite, mais pas sur la gauche
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right), 10f * Time.deltaTime);   //Mouvement droite
            }
            else if(obstacleOnRight && !obstacleOnLeft) //La voie est dégagée sur la gauche, mais pas sur la droite
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.left), 10f * Time.deltaTime);    //Mouvement gauche
            }
        }
        
        else if(obstacleOnRight && !obstacleOnLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.left), 10f * Time.deltaTime);
        }

        else if(obstacleOnLeft && !obstacleOnRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right), 10f * Time.deltaTime);
        }
    }
}
