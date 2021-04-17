using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Matis Duperray
/// Fonctions de bases des ennemis
/// </summary>
public class GlobalEnnemiBehavior : MonoBehaviour
{
    public int life;

    public bool isAlive = true;

    public LayerMask obstacleMask;
    public LayerMask playerMask;
    public LayerMask somethingBehindMask;


    public float speedMultiplicator = 1f;


    RaycastHit hit;

    bool obstacleAhead = false;
    bool obstacleOnRight = false;
    bool obstacleOnLeft = false;
    bool somethingBehind = false;

    public bool playerOnRight = false;
    public bool playerOnLeft = false;
    public bool isLeaving = false;

    bool playerCloseOnRight = false;
    bool playerCloseOnLeft = false;

    bool isOnSideCoroutine = false;

    Vector3 directionToMoveOn = Vector3.right;

    internal void Death()
    {
        throw new System.NotImplementedException();
    }

    public void MoveBack(bool stopAtPlayerPos) //Move vers l'arrière, jusqu'à ce qu'il atteigne la position du player. Des lors, il se stop.
    {
        if(stopAtPlayerPos == false)
        {
            if(GameManager.Instance.playerManager.playerIsBoosting)
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed/ (speedMultiplicator/5) * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed / speedMultiplicator * Time.deltaTime);
            }
            
        }
        else if(stopAtPlayerPos == true)
        {
            if(transform.position.z > GameManager.Instance.playerManager.player.transform.position.z)
            {
                if (GameManager.Instance.playerManager.playerIsBoosting)
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed / (speedMultiplicator / 5) * Time.deltaTime);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed / speedMultiplicator * Time.deltaTime);
                }
            }
            else
            {
                if(!isLeaving)
                {
                    if (!isOnSideCoroutine && !isLeaving)
                    {
                        StartCoroutine(waitSideOfPlayer());
                    }
                    transform.position = Vector3.MoveTowards(transform.position, transform.position, 0f);
                }
                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed / speedMultiplicator * Time.deltaTime);
                }
            }
        }

    }
    public void Movement() //Permet aux ennemis d'esquiver les rochers, les ennemis et le joueurs
    {
        if(obstacleAhead == true || somethingBehind == true)   //L'ennemi fait face à un obstacle
        {
            if(!obstacleOnRight && !obstacleOnLeft && !playerCloseOnRight && !playerCloseOnLeft) //La voie est dégagée des deux côtés
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (directionToMoveOn), 8f*Time.deltaTime);
            }
            else if((obstacleOnLeft || playerCloseOnLeft) && (!obstacleOnRight || !playerCloseOnRight)) //La voie est dégagée sur la droite, mais pas sur la gauche
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right), 8f * Time.deltaTime);   //Mouvement droite
            }
            else if((obstacleOnRight || playerCloseOnRight) && (!obstacleOnLeft || !playerCloseOnLeft)) //La voie est dégagée sur la gauche, mais pas sur la droite
            {
                transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.left), 8f * Time.deltaTime);    //Mouvement gauche
            }
        }
        
        else if(obstacleOnRight && !obstacleOnLeft)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.left), 8f * Time.deltaTime);
        }

        else if(obstacleOnLeft && !obstacleOnRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.right), 8f * Time.deltaTime);
        }
    }


    public void CheckDirection() //Vérfie les obstacles devant l'ennemi
    {
        #region Debug
        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
        Debug.DrawRay(transform.position, (transform.forward + transform.right / 3) * 20, Color.red);
        Debug.DrawRay(transform.position, (transform.forward - transform.right / 3) * 20, Color.red);
        #endregion

        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f, obstacleMask)) //Devant
        {
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

    }
    public void CheckForPlayer() //Vérifie la position du joueur sur les côté de l'ennemi
    {
        #region Debug
        Debug.DrawRay(transform.position, transform.right * 20, Color.blue);
        Debug.DrawRay(transform.position, -transform.right * 20, Color.blue);
        #endregion


        if (Physics.Raycast(transform.position, transform.right, out hit, 20f, playerMask)) //Côté droit
        {
            playerOnRight = true;
        }
        else
        {
            playerOnRight = false;
        }

        if (Physics.Raycast(transform.position, -transform.right, out hit, 20f, playerMask)) //Côté gauche
        {
            playerOnLeft = true;
        }
        else
        {
            playerOnLeft = false;
        }



        Transform playerTransform = GameManager.Instance.playerManager.player.transform;
        if(playerOnLeft && transform.position.x <= playerTransform.position.x+5)
        {
            playerCloseOnLeft = true;
        }
        else
        {
            playerCloseOnLeft = false;
        }

        if(playerOnRight && transform.position.x >= playerTransform.position.x - 5)
        {
            playerCloseOnRight = true;
        }
        else
        {
            playerCloseOnRight = false;
        }
    }
    public void CheckBehind() //Vérifie ce qui se trouve derrière l'ennemi
    {
        #region Debug
        Debug.DrawRay(transform.position + Vector3.right, -transform.forward * 5, Color.green);
        Debug.DrawRay(transform.position, -transform.forward * 5, Color.green);
        Debug.DrawRay(transform.position - Vector3.right, -transform.forward * 5, Color.green);
        #endregion

        if (Physics.Raycast(transform.position + Vector3.right, -transform.forward, out hit, 5f, somethingBehindMask) || Physics.Raycast(transform.position - Vector3.right, -transform.forward, out hit, 5f, somethingBehindMask) || Physics.Raycast(transform.position, -transform.forward, out hit, 5f, somethingBehindMask))
        {
            somethingBehind = true;
        }
        else
        {
            somethingBehind = false;
        }
    }


    public void Death(List<GameObject> list) //Remet le joueur sur l'emplacement de stockage
    {
        GameManager.Instance.ennemiManager.ennemiList.Remove(this.gameObject);
        this.transform.position = GameManager.Instance.otherWorldManager.otherWorld.position;
        isAlive = false;
        list.Add(this.gameObject);
    }
    public void GlobalReset() //Rétablie toute les valeurs communes à tout les ennemis à leur valeur de base
    {
        transform.position = Vector3.zero;
        obstacleAhead = false;
        obstacleOnRight = false;
        obstacleOnLeft = false;
        somethingBehind = false;

        playerOnRight = false;
        playerOnLeft = false;
        isLeaving = false;

        playerCloseOnRight = false;
        playerCloseOnLeft = false;

        isOnSideCoroutine = false;

        directionToMoveOn = Vector3.right;
}




    public IEnumerator RandomiseDirection() //Change la direction que l'ennemi utilise pour esquiver un obstacle
    {
        directionToMoveOn = GiveNewMovementDirection();
        yield return new WaitForSeconds(5f);
        StartCoroutine(RandomiseDirection());
    }
    IEnumerator waitSideOfPlayer() //Stop l'ennemi pendant un temps donné lorsqu'il arrive au niveau du joueur
    {
        isOnSideCoroutine = true;
        yield return new WaitForSeconds(GameManager.Instance.ennemiManager.arrestSideOfPlayerDuration);
        isLeaving = true;
    }

    Vector3 GiveNewMovementDirection() //Gère la fréquence à laquelle la direction d'esquive change
    {
        int randomN = Random.Range(1, 3);

        if(randomN == 1)
        {
            return Vector3.right;
        }
        else if(randomN == 2)
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
