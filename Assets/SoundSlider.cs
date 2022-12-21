using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        float volume = audioSlider.value;

        if (volume == -40f) audioMixer.SetFloat("BGM", -80);
        else audioMixer.SetFloat("BGM", volume);

    }
    
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
