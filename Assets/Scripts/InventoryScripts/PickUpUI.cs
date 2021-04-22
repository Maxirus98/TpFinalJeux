using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Image image;
    public Canvas canvas;
    private float _radius;
    private Transform _playerTransform;
    void Start()
    {
        _radius = GetComponentInParent<ItemController>().radius;
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        image.transform.position = pos;
        float distance = Vector3.Distance(_playerTransform.position, gameObject.transform.position);
        print(distance);
        if (distance <= _radius)
        {
            canvas.gameObject.SetActive(true);
        }
        if(distance > _radius && canvas.gameObject.activeSelf)
        {
            canvas.gameObject.SetActive(false);
        }
    }

    public IEnumerator SetActiveInactive()
    {
        canvas.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.01f);
    }
}
