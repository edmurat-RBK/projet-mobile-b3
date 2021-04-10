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
    public float rangeMoissoneuse;
    public float rangeCopilote;
    public float rangeLanceFlammes;
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
        
        }

        switch (myWeapon)
        {
            case WeaponType.Moissoneuse:
                Moissoneuse();
                break;
            case WeaponType.Copilote:
                Copilote();
                break;
            case WeaponType.MiniGrue:
                Grue();
                break;
            case WeaponType.LanceFlames:
                LanceFlammes();
                break;    
            case WeaponType.Enceintes:
                Enceintes();
                break;
            default:
                break;
        }
        
    }

    void Moissoneuse()
    {
        Debug.DrawRay(transform.position, transform.forward * rangeMoissoneuse, Color.red);
                if (Physics.Raycast(transform.position,transform.forward,out hit, rangeMoissoneuse,ennemis))
                {
                    hit.transform.GetComponent<GlobalEnnemiBehavior>().Death();
                }
    }

    void Copilote()
    {
        Debug.DrawRay(transform.position, (transform.right + transform.forward) * rangeCopilote, Color.red);
                Debug.DrawRay(transform.position, (-transform.right + transform.forward) * rangeCopilote, Color.red);
                if (Physics.Raycast(transform.position,transform.right + transform.forward,out hit, rangeCopilote,ennemis))
                {
                    hit.transform.GetComponent<GlobalEnnemiBehavior>().Death();
                    Debug.Log("Tue ennemi de droite avec le copilote");
                }
                if (Physics.Raycast(transform.position,-transform.right + transform.forward,out hit, rangeCopilote,ennemis))
                {
                    hit.transform.GetComponent<GlobalEnnemiBehavior>().Death();
                    Debug.Log("Tue ennemi de gauche avec le copilote");
                }
    }

    void LanceFlammes()
    {
        Debug.DrawRay(transform.position, transform.right * rangeLanceFlammes, Color.red);
                Debug.DrawRay(transform.position, -transform.right * rangeLanceFlammes, Color.red);
                if (Physics.Raycast(transform.position,transform.right,out hit, rangeLanceFlammes,ennemis))
                {
                    hit.transform.GetComponent<GlobalEnnemiBehavior>().Death();
                    Debug.Log("Tue ennemi de droite avec le lance flammes");
                }
                if (Physics.Raycast(transform.position,-transform.right,out hit, rangeLanceFlammes,ennemis))
                {
                    hit.transform.GetComponent<GlobalEnnemiBehavior>().Death();
                    Debug.Log("Tue ennemi de gauche avec le lance flammes");
                }
    }

    void Grue()
    {

    }

    void Enceintes()
    {

    }
}
