using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSlider : MonoBehaviour {
    public AudioMixer audioMixer;
    public static float masterVolume = 0;

    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        masterVolume = volume;
    }
}
