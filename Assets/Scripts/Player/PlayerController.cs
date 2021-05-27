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
    public Animator animator;
    public float speed;
    public bool move;
    public bool movePrio;
    bool inertia;
    public Vector3 direction;
    public Vector3 direction2;
    Quaternion target;
    Rigidbody rb;
    [Range (0,1)]
    public float inertiaTiming;
    public float rotateSpeed;
    [Range(0,50)]
    public float maxRota;


    PlayerManager playerManager;


    [Header("Audio")]
    AudioManager audioManager;
    AK.Wwise.RTPC localMotorRTCP;
    int motorVar = 0;
    


    bool isBumped = false;



    private void OnEnable()
    {
        InputManager.OnStartTouch1 += Move;
        InputManager.OnEndTouch1 += Move;
        InputManager.OnStartTouch2 += MovePrio;
        InputManager.OnEndTouch2 += MovePrio;
    }
    private void OnDisable()
    {
        if(!isBumped)

        {

            InputManager.OnStartTouch1 -= Move;

            InputManager.OnEndTouch1 -= Move;

            InputManager.OnStartTouch2 -= MovePrio;

            InputManager.OnEndTouch2 -= MovePrio;

        }
    }



    private void Move(Vector2 position)
    {
        
        if (position == Vector2.zero)
        {
            position.x = Screen.width / 2;
        }
        move = !move;
        if (position.x <= Screen.width / 3)
        {
            
            direction.x = -1;
        }
        else if (position.x > (Screen.width / 3) * 2)
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
        if (position.x <= Screen.width /3)
        {
            
            direction2.x = -1;
        }
        else if (position.x > (Screen.width /3) * 2)
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
        GameManager.Instance.playerManager.player = this.gameObject;

        playerManager = GameManager.Instance.playerManager;

        audioManager = AudioManager.AMInstance;
        localMotorRTCP = audioManager.motorVarRTPC;
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
        if(ShopManager.Instance.shopActive) {
            return;
        }
        transform.rotation = Quaternion.RotateTowards(transform.rotation,target,rotateSpeed*Time.deltaTime);
        animator.SetFloat("HorizontalSpeed",direction.x);
        if (move && !movePrio || inertia)
        {
            if(move)
            {
                inertia = true;
            }
            if(inertia && !move)
            {
                Invoke("Inertia", inertiaTiming);
            }
            switch (direction.x)
            {
                case 1:
                target = Quaternion.Euler(new Vector3(0,180, maxRota));
                
                    break;
                case -1:
                target = Quaternion.Euler(new Vector3(0,180, -maxRota));
                
                    break;
                case 0:
                target = Quaternion.Euler(new Vector3(0,180, 0));
                
                    break;
                default:
                    break;
            }
            
            transform.position = Vector3.MoveTowards(transform.position,transform.position + direction,speed*Time.deltaTime); //déplace le joueur selon le vecteur et la vitesse */

            if (motorVar <= 20)
            {
                if (playerManager.playerIsBoosting == false)
                {
                    motorVar += 2;
                    localMotorRTCP.SetGlobalValue(motorVar);
                }
            }


            //rb.velocity = direction*speed*Time.deltaTime *100; //fait bouger le vaisseau dans la bonne direction

        }
        else if (movePrio)
        {
            transform.position = Vector3.MoveTowards(transform.position,transform.position + direction,speed*Time.deltaTime);

            if (motorVar <= 20)
            {
                if (playerManager.playerIsBoosting == false)
                {
                    motorVar += 2;
                    localMotorRTCP.SetGlobalValue(motorVar);
                }

            }
        }
        if (!move)
        {
            direction.x = 0;
            direction2.x = 0;

            if (motorVar > 0)
            {
                if(playerManager.playerIsBoosting == false)
                {
                    motorVar = 0;
                    localMotorRTCP.SetGlobalValue(0);
                }
            }
        }
        if(isBumped)
        {

            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);

        }
    }

    void Inertia() // pour ismuler de l'inertie
    {
        inertia = false;
    }



    public IEnumerator playerBumped(Vector3 _direction)

    {

        direction = _direction;

        isBumped = true;

        yield return new WaitForSeconds(0.5f);

        isBumped = false;

        direction = Vector3.zero;

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Shop Trigger") {
            Time.timeScale = 0;
            ShopManager.Instance.shopActive = true;
            ShopManager.Instance.shopUI.SetActive(true);
        }
    }

}
