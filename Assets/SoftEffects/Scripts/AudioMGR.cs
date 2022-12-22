using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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
    [SerializeField] AudioMixer audioMixer;

    public void PlaySound(SoundList sd)
    {
        if (sd == SoundList.Jump)
        {
            SFX[0].Play();
        }
        else if (sd == SoundList.Die)
        {
            if (Random.Range(0, 2) == 1)
                SFX[1].Play();
            else
                SFX[2].Play();
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
