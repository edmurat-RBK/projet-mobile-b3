using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
