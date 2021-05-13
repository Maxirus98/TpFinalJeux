using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradientColor;
    public Image image;
    public void SetMaxHp(float hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

        image.color = gradientColor.Evaluate(1f);
    }

    public void SetHp(float hp)
    {
        slider.value = hp;
        image.color = gradientColor.Evaluate(slider.normalizedValue);
    }
}
