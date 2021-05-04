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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator Heal()
    {
        gameObject.SetActive(true);
        transform.position = _playerTransform.position;
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        StopCoroutine(Heal());

    }

}