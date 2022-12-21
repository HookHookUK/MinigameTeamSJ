using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundList
{
    Jump,
    Die,
    BGM1,
    BGM2,
}
public class AudioMGR : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] AudioClip JumpSound;
    [SerializeField] AudioClip DieSound;
    [SerializeField] AudioClip[] BGM;

    public AudioClip PlaySound(SoundList sd)
    {
        if (sd == SoundList.Jump)
        {
            return JumpSound;
        }
        else if (sd == SoundList.Die)
        {
            return DieSound;
        }
        else if (sd == SoundList.BGM1)
        {
            return BGM[0];
        }
        else if (sd == SoundList.BGM2)
        {
            return BGM[1];
        }
        return null;
    }
}
