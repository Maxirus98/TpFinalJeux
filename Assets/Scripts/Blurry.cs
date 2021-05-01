using System;
using System.Collections.Generic;
using System.IO;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blurry : MonoBehaviour
{
    public Material material;
    private Image _image;
    private Button _button;
    private TextMeshProUGUI _textMeshPro;
    private string _dimensionName;

    void Start()
    {
        _image = GetComponentInChildren<Image>();
        _button = GetComponentInChildren<Button>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        Blurriness();
    }

    void Blurriness()
    {
        _dimensionName = _textMeshPro.text.ToLower();
        string dimensions = LevelTrackerService.GetOne(_dimensionName);
        
           // _button.gameObject.SetActive(true);
           // _image.material = null;
    }

}