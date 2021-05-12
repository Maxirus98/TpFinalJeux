using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        _particleSystem = GetComponent<ParticleSystem>();
        _particleSystem.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Boss") == null && !_particleSystem.isPlaying)
        {
            StartCoroutine(OnVoidAppear());
        }
    }

    public IEnumerator OnVoidAppear()
    {
        transform.position = _playerTransform.position;
        transform.LookAt(_playerTransform);
        _particleSystem.Play();
        yield return new WaitForSeconds(5f);
        GameManager.Instance.LoadLevel("SelectLevel");
    }
}