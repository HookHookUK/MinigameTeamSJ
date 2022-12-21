using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundList
    {
        Jump,
        Die,
        Start,
        BGM1,
        BGM2,
    }   
public class AudioMGR : MonoBehaviour
{

    [SerializeField] AudioSource[] BGM;
    [SerializeField] AudioSource[] SFX;

    public void PlaySound(SoundList sd)
    {
        if (sd == SoundList.Jump)
        {
            SFX[0].Play();
        }
        else if (sd == SoundList.Die)
        {
            SFX[1].Play();
        }
        else if (sd == SoundList.Start)
        {
            BGM[0].Play();

            BGM[1].Stop();
        }
        else if (sd == SoundList.BGM1)
        {
            BGM[1].Play();

            BGM[0].Stop();
        }
        else if (sd == SoundList.BGM2)
        {
            BGM[2].Play();
        }
    }
}
