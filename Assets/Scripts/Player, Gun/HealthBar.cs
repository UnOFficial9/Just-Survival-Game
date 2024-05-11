using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public HealthPlayer hp;
    private Slider slider;
    public Text text;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = hp.maxHealth;
        
    }
    private void Update()
    {
        slider.value = hp.health;
        text.text = hp.health + "/" + hp.maxHealth;

    }
}
