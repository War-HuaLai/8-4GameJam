using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIControl : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public void MusicVolume()
    {
        AudioManger.Instance.MusicVolume(_musicSlider.value);
    }


    public void SfxVolume()
    {
        AudioManger.Instance.SfxVolume(_sfxSlider.value);
    }


    public void ToggleMusic()
    {
        AudioManger.Instance.ToggleMusic();
    }
    public void ToggleSfx()
    {
        AudioManger.Instance.ToggleSfx();
    }
}