using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalPiece : MonoBehaviour
{
    public int totalPiece;
    public static TotalPiece tpinstance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (tpinstance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            tpinstance = this;
        }
    }
    void Start()
    {
        totalPiece = 0;
    }

}
