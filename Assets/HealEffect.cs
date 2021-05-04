using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class HealEffect : MonoBehaviour
{
    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    public IEnumerator Effect()
    {
        gameObject.SetActive(true);
        transform.position = _playerTransform.position;
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        StopCoroutine(Effect());

    }

}