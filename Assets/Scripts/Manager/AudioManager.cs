using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager AMInstance;


        [Header("SFX")]
    #region Player
    public AK.Wwise.Event playerMotorAudio;
    public AK.Wwise.Event playerBoostAudio;
    #endregion
    #region World
    public AK.Wwise.Event coinCollectAudio;
    public AK.Wwise.Event rockDestructionAudio;
    public AK.Wwise.Event explosionAudio;
    #endregion
    #region UI
    public AK.Wwise.Event UISelectAudio;
    public AK.Wwise.Event UICloseAudio;
    public AK.Wwise.Event UIImpossibleAudio;
    public AK.Wwise.Event UIPauseAudio;
    public AK.Wwise.Event UIUnpauseAudio;
    public AK.Wwise.Event UIStartAudio;
    public AK.Wwise.Event UIReturnMenuAudio;
    #endregion
    #region Enemy
    public AK.Wwise.Event enemyMotorAudio;
    #endregion



    //---------------------------------------------------
    [Header("Musics")]
    public AK.Wwise.Event runMusic;



    //---------------------------------------------------
        [Header("Game Sync")]
    //Variable "motorVar" dans PlayerController
    public AK.Wwise.RTPC motorVarRTPC;
    public AK.Wwise.RTPC boostEvolutionRTPC;






    private void Awake()
    {
        if(AudioManager.AMInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            AudioManager.AMInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        UIReturnMenuAudio.Post(gameObject);
        runMusic.Post(gameObject);     
    }


    public void StopAllAudio()
    {
        runMusic.Stop(gameObject);
        playerMotorAudio.Stop(gameObject);
    }
}
