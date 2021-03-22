using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public enum WeaponType
    {
        Moissoneuse,
        Copilote,
        MiniGrue,
        LanceFlames,
        Enceintes
    };
    public WeaponType myWeapon;


    public LayerMask ennemis;
    public float range;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (myWeapon == WeaponType.Moissoneuse)
        {
            Debug.DrawRay(transform.position, transform.forward * range, Color.red);
        if (Physics.Raycast(transform.position,transform.forward,out hit, range,ennemis))
        {
            hit.transform.GetComponent<GlobalEnnemiBehavior>().Death();
        }
        }
        
    }
}
