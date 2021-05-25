using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    Boost boostRef;
    public int enemiesDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        boostRef = GetComponent<Boost>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ennemy") && boostRef.isBoosting)
        {
            collision.gameObject.GetComponent<GlobalEnnemiBehavior>().life --;
            GetComponent<PlayerLife>().enemiesDestroyed += 1;
            GameManager.Instance.playerManager.player.GetComponent<PlayerController>().animator.SetTrigger("Kill");
            Debug.Log("KABOOOOOM");
        }
    }
}
