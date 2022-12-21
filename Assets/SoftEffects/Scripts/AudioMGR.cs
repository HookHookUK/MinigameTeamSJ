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
        return null;
    }
}
