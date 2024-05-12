using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;

public class SettingsSaves
{
    public bool muted;
    public bool spawnEnemies;
    public int graphics;
    public int[] sounds = new int[3];
}

public class Settings : MonoBehaviour
{
    public Slider musicSlider;
    public Slider shootsSlider;
    public Slider volume;
    public Toggle mute;
    public Toggle enemies;
    public Dropdown graphics;
    public AudioMixer mixer;
    private SettingsSaves saves = new SettingsSaves();
    void Start()
    {
        string path = Application.persistentDataPath + "/Settings.json";
        if (File.Exists(path))
        {
            InitSaves();
        }
        else
        {
            File.Create(path);   
            musicSlider.value = musicSlider.maxValue;
            shootsSlider.value = shootsSlider.maxValue;
            volume.value = volume.maxValue;
        }
        
    }
    void Update()
    {
        string path = Application.persistentDataPath + "/Settings.json";
        mixer.SetFloat("allVol", volume.value);
        mixer.SetFloat("musicVol", musicSlider.value);
        mixer.SetFloat("shootsVol", shootsSlider.value);
        saves.sounds[0] = (int)musicSlider.value;
        saves.sounds[1] = (int)shootsSlider.value;
        saves.sounds[2] = (int)volume.value;
        saves.graphics = graphics.value;
        saves.muted = mute.isOn;
        saves.spawnEnemies = enemies.isOn;
        File.WriteAllText(path, JsonUtility.ToJson(saves));
    }
    void InitSaves()
    {
        string path = Application.persistentDataPath + "/Settings.json";
        string json = File.ReadAllText(path);
        saves.sounds[0] = JsonUtility.FromJson<SettingsSaves>(json).sounds[0];
        saves.sounds[1] = JsonUtility.FromJson<SettingsSaves>(json).sounds[1];
        saves.sounds[2] = JsonUtility.FromJson<SettingsSaves>(json).sounds[2];
        saves.graphics = JsonUtility.FromJson<SettingsSaves>(json).graphics;
        saves.spawnEnemies = JsonUtility.FromJson<SettingsSaves>(json).spawnEnemies;
        saves.muted = JsonUtility.FromJson<SettingsSaves>(json).muted;


        musicSlider.value = JsonUtility.FromJson<SettingsSaves>(json).sounds[0];
        shootsSlider.value = JsonUtility.FromJson<SettingsSaves>(json).sounds[1];
        volume.value = JsonUtility.FromJson<SettingsSaves>(json).sounds[2];
        mute.isOn = JsonUtility.FromJson<SettingsSaves>(json).muted;
        enemies.isOn = JsonUtility.FromJson<SettingsSaves>(json).spawnEnemies;
        graphics.value = JsonUtility.FromJson<SettingsSaves>(json).graphics;
    }
}
