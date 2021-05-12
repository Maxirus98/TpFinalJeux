using System;
using TMPro;
using UnityEngine;

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

        else if(Math.Abs(timeLeft) == 30)
        {
          _audioSource.Play();  
        }
        
        else
        {
            timeLeft = 0;
            _audioSource.Stop();
            GameManager.Instance.LoadLevel("GameOver");
        }
        _audioSource.loop = timeLeft <= 30 && timeLeft >= 0;
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

        _textMeshPro.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}