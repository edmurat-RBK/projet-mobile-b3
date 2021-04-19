using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AMInstance;


        [Header("SFX")]
    #region Player
    public AK.Wwise.Event playerMotorAudio;
    #endregion



    //---------------------------------------------------
        [Header("Musics")]
    public AK.Wwise.Event runMusic;



    //---------------------------------------------------
        [Header("Game Sync")]
    //Variable "motorVar" dans PlayerController
    public AK.Wwise.RTPC motorVarRTPC;






    private void Awake()
    {
        if(AudioManager.AMInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.AMInstance = this;
        }
    }


    private void Start()
    {
        runMusic.Post(gameObject);
        playerMotorAudio.Post(gameObject);
    }





    public void StopAllAudio()
    {
        runMusic.Stop(gameObject);
        playerMotorAudio.Stop(gameObject);
    }
}
