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
    [Range (0,1)]
    public float inertiaTiming;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void OnMove(InputValue value) //recupère le vecteur qui correspond à la direction donnée
    {
        move = !move;
        direction.x = value.Get<Vector2>().x; //prends la direction du mouvement uniquement sur les cotés
        
    }
    public void OnMouseMove(InputValue value) //recupère le vecteur qui correspond à la direction donnée
    {
        move = !move;

        if (Mouse.current.position.ReadValue().x < Screen.width / 4)
        {
            direction.x = -1;
        }
        else if (Mouse.current.position.ReadValue().x > (Screen.width / 4) * 3)
        {
            direction.x = 1;
        }
        else
        {
            direction = Vector3.zero;
        }
        //direction.x = value.Get<Vector2>().x;

    }
    
    private void Update()
    {
        if (move)
        {
            /*transform.position += direction * speed * Time.deltaTime; //déplace le joueur selon le vecteur et la vitesse */
            
            rb.velocity = direction; //fait bouger le vaisseau dans la bonne direction
            
        }
        else
        {
            Invoke("Inertia", inertiaTiming);
        }
        
    }

    void Inertia() // pour ismuler de l'inertie
    {
        rb.velocity = Vector3.zero;
    }

}
