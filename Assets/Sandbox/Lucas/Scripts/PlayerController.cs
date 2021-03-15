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
    public bool move;
    bool movePrio;
    public Vector3 direction;
    public Vector3 direction2;
    Rigidbody rb;
    [Range (0,1)]
    public float inertiaTiming;

    private void OnEnable()
    {
        InputManager.OnStartTouch1 += Move;
        InputManager.OnEndTouch1 += Move;
        InputManager.OnStartTouch2 += MovePrio;
        InputManager.OnEndTouch2 += MovePrio;
    }
    private void OnDisable()
    {
        InputManager.OnStartTouch1 -= Move;
        InputManager.OnEndTouch1 -= Move;
        InputManager.OnStartTouch2 -= MovePrio;
        InputManager.OnEndTouch2 -= MovePrio;
    }



    private void Move(Vector2 position)
    {
        if (position == Vector2.zero)
        {
            position.x = Screen.width / 2;
        }
        move = !move;
        if (position.x <= Screen.width / 4)
        {
            
            direction.x = -1;
        }
        else if (position.x > (Screen.width / 4) * 3)
        {
            direction.x = 1;
            
        }
        else
        {
            direction.x = 0;
        }
    }

    private void MovePrio(Vector2 position)
    {
        movePrio = !movePrio;
        if (position.x <= Screen.width / 4)
        {
            
            direction2.x = -1;
        }
        else if (position.x > (Screen.width / 4) * 3)
        {
            direction2.x = 1;
            
        }
        else
        {
            direction2.x = 0;
        }
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //public void OnMove(InputValue value) //recupère le vecteur qui correspond à la direction donnée
    //{
    //    move = !move;
    //    direction.x = value.Get<Vector2>().x; //prends la direction du mouvement uniquement sur les cotés
        
    //}
    //public void OnMouseMove(InputValue value) //recupère le vecteur qui correspond à la direction donnée
    //{
    //    move = !move;

    //    if (Mouse.current.position.ReadValue().x < Screen.width / 4)
    //    {
    //        direction.x = -1;
    //    }
    //    else if (Mouse.current.position.ReadValue().x > (Screen.width / 4) * 3)
    //    {
    //        direction.x = 1;
    //    }
    //    else
    //    {
    //        direction = Vector3.zero;
    //    }
    //    //direction.x = value.Get<Vector2>().x;

    //}
    
    private void Update()
    {
        if (move && !movePrio)
        {
            /*transform.position += direction * speed * Time.deltaTime; //déplace le joueur selon le vecteur et la vitesse */
            
            rb.velocity = direction*speed*Time.deltaTime; //fait bouger le vaisseau dans la bonne direction
            
        }
        else if (movePrio)
        {
            rb.velocity = direction2*speed*Time.deltaTime;
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
