using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Musics")]
    [Space(10)]

    public AK.Wwise.Event runMusic;





    private void Start()
    {
        runMusic.Post(gameObject);
    }
}
