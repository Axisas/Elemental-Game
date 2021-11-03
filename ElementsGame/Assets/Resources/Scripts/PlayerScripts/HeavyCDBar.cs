using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeavyCDBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(int cooldown)
    {
        slider.maxValue = cooldown;
        slider.value = 5;
    }
    
    public void SetValue(float cooldown)
    {
        slider.value = cooldown;
    }
    
}