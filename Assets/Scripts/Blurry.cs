using System;
using System.Collections.Generic;
using System.IO;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blurry : MonoBehaviour
{
    private Image _image;
    private TextMeshProUGUI _textMeshPro;
    private string _dimensionName;

    void Start()
    {
        _image = GetComponentInChildren<Image>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        Blurriness();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Blurriness()
    {
        _dimensionName = _textMeshPro.text;
        string[] dimensions = LevelTrackerService.Get().Split(',');
        string keyPair = GetKeyValuePair(dimensions);
        print(_textMeshPro.name + _image.material.name);
        // print(LevelTrackerService.Get().Split(',')[0]);
    }

    public void Clear()
    {
    }

    private string GetKeyValuePair(string[] pairs)
    {
        foreach (var pair in pairs)
        {
            if (pair.Split(':')[0].Equals(_dimensionName))
                return pair;
        }
        return String.Empty;
    }
}