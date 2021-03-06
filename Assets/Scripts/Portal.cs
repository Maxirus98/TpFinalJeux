using System.Collections;
using System.Collections.Generic;
using NpcScripts;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private AudioSource _audioSource;
    private 

    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (GameObject.Find("Boss") == null && 
            NpcManager.Instance.GetNbrNpcAlive() == 0
            && _particleSystem.isStopped)
        {
            StartCoroutine(OnVoidAppear());
        }
    }

    public IEnumerator OnVoidAppear()
    {
        _particleSystem.Play();
        _audioSource.Play();
        yield return new WaitForSeconds(5f);
        GameManager.Instance.LoadLevel("SelectLevel");
    }
}