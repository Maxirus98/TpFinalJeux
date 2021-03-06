using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 600;
    private TextMeshProUGUI _textMeshPro;
    private AudioSource _audioSource;

    void Awake()
    {
        _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        _audioSource = GetComponent<AudioSource>();
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
        {
            _textMeshPro.color = Color.red;
        }

        if (seconds == 30 && minutes == 0)
        {
            _audioSource.Play();  
        }

        _textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}