using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject boss;
    public GameObject waveManager;
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;
    private 

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        _particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null && waveManager.GetComponentInChildren<GameObject>()== null)
        {
            StartCoroutine(OnVoidAppear());
        }
    }

    public IEnumerator OnVoidAppear()
    {
        _particleSystem.Play();
        yield return new WaitForSeconds(5f);
        GameManager.Instance.LoadLevel("SelectLevel");
    }
}