using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Core
{
    public class SettingsMenuController: MonoBehaviour
    {
        public Slider musicVolumeSlider;

        void Start() {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        }
        public void updateMusicVolume() {
            PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
            SoundManager.instance.musicVolumeChanged();
        }
        
    }
}