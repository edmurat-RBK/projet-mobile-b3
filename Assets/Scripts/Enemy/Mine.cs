using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + (Vector3.back * 100), GameManager.Instance.terrainManager.scrollSpeed * Time.deltaTime);

        if (transform.position.z < GameManager.Instance.ennemiManager.deadZone.position.z)
        {
            Destroy(gameObject);
        }
    }
}
