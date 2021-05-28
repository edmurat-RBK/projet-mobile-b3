using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AK.Wwise.RTPC volume;
    public Scrollbar scroll;


    private void Update()
    {
        volume.SetGlobalValue(scroll.value);
    }
}
