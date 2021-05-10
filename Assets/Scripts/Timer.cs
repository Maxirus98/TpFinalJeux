using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeLeft = 600;
    private TextMeshProUGUI _textMeshPro;

    void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        print(_textMeshPro.name);
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;
            GameManager.Instance.LoadLevel("GameOver");
        }

        DisplayTime(timeLeft);
    }

    void DisplayTime(float time)
    {
        if (time < 0)
        {
            time = 0;
        }
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        if (minutes < 1)
            _textMeshPro.color = Color.red;
        _textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}