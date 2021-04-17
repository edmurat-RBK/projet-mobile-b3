using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("SFX")]
    #region Player
    public AK.Wwise.Event playerMotorAudio;
    #endregion



    //---------------------------------------------------
    [Header("Musics")]
    public AK.Wwise.Event runMusic;



    //---------------------------------------------------
    [Header("Game Sync")]
    public int motorVar;
    public AK.Wwise.RTPC motorVarRTPC;

    

    





    private void Start()
    {
        runMusic.Post(gameObject);
        playerMotorAudio.Post(gameObject);
    }
}
