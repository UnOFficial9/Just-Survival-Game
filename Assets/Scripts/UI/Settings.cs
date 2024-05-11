using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Settings : MonoBehaviour
{
    public Slider volume;
    public Toggle mute;
    public Toggle enemies;
    public Dropdown graphics;
    void Start()
    {
        volume.maxValue = 1;
        volume.minValue = 0;
        volume.value = PlayerPrefs.GetFloat("volume");
        if (PlayerPrefs.GetString("enemies") == "True")
            enemies.isOn = true;
        else
            enemies.isOn = false;
        graphics.value = QualitySettings.GetQualityLevel();
    }
    void Update()
    {
        if(!mute.isOn)
        PlayerPrefs.SetFloat("volume" ,volume.value);
        if (mute.isOn)
            PlayerPrefs.SetFloat("volume", 0f);
        PlayerPrefs.SetString("enemies", enemies.isOn.ToString());
        QualitySettings.SetQualityLevel(graphics.value);
    }
    
}
