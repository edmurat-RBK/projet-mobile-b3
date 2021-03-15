using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public bool playerIsAlive;

    public float maxPlayerLife = 10f;
    public float playerLife = 10f;

    public float lifeDecreaseSpeed = 1f;
    public float decreaseMultiplicator = 0f;
}
