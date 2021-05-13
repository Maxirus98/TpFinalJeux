using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform _playerTransform;
    private ParticleSystem _particleSystem;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }
    public IEnumerator Effect()
    {
        transform.position = _playerTransform.position;
        _particleSystem.Play();
        yield return new WaitForSeconds(5f);
        _particleSystem.Stop();
        StopCoroutine(Effect());
    }
}