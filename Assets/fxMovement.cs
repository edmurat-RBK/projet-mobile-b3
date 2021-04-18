﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxMovement : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(timeBeforeDestroy());
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed/1.5f * Time.deltaTime);
    }


    IEnumerator timeBeforeDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
