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
    public void SetMaxHp(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

        image.color = gradientColor.Evaluate(1f);
    }

    public void SetHp(int hp)
    {
        slider.value = hp;
        image.color = gradientColor.Evaluate(slider.normalizedValue);
    }
}
