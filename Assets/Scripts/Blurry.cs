using System;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blurry : MonoBehaviour
{
    public Image image;
    private Button _button;
    private TextMeshProUGUI _textMeshPro;
    private string _dimensionName;
    void Start()
    {
        _button = GetComponentInChildren<Button>();
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        DisableBlurriness();
    }

    void DisableBlurriness()
    {
        _dimensionName = _textMeshPro.text.ToLower();
        string name = LevelTrackerService.Get(_dimensionName);

        if (!name.Equals(String.Empty))
        {
            _button.interactable = true;
            image.material = null;
            Debug.Log("Disable blurry");
        }
    }
}