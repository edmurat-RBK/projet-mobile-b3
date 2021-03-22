using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Matis Duperray
/// Sers juste à réferencer l'objet dans le Start
/// </summary>
public class EnnemiDeadZone : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.ennemiManager.deadZone = this.transform;
    }
}
