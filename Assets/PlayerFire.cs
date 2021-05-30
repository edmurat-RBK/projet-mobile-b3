using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{

    public LayerMask fireLayer;
    RaycastHit raycastHit;
    bool canTakeDamage = true;

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.position + Vector3.forward * 5, out raycastHit, 20f, fireLayer) && canTakeDamage)
        {
            if (GameManager.Instance.playerManager.shield <= 0)
            {
                GameManager.Instance.playerManager.playerLife -= 1;

            }
            else
            {
                GameManager.Instance.playerManager.shield -= 1;
            }
            canTakeDamage = false;
            StartCoroutine(waitForDamage());
            Debug.Log("okidoki");
        }
    }

    IEnumerator waitForDamage()
    {
        yield return new WaitForSeconds(.3f);
        canTakeDamage = true;
    }
    // void OnTriggerStay(Collider other)
    // {
    //     if (other.tag == "Fire")
    //     {
    //         if (GameManager.Instance.playerManager.shield <= 0)
    //         {
    //             GameManager.Instance.playerManager.playerLife -= 1;

    //         }
    //         else
    //         {
    //             GameManager.Instance.playerManager.shield -= 1;
    //         }

    //     }
    // }

}
