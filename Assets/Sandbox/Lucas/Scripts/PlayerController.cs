using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Lucas DEUTSCHMANN
/// Player Controller
/// </summary>
[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    public float speed;
    bool move;
    Vector3 direction;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value) //recupère le vecteur qui correspond à la direction donnée
    {
        move = !move;
        direction = value.Get<Vector2>();
        
    }
    private void Update()
    {
        if (move)
        {
            transform.position += direction * speed * Time.deltaTime; //déplace le joueur selon le vecteur et la vitesse 
           // rb.MovePosition(transform.position + (direction * speed * Time.deltaTime));
            //rb.AddForce(direction);
        }
        
    }

}
