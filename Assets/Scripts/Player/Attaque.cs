using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attaque : MonoBehaviour
{
    Boost boostRef;
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
            collision.gameObject.GetComponent<GlobalEnnemiBehavior>().Death();
            Debug.Log("KABOOOOOM");
        }
    }
}
