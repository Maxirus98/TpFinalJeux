using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float smoothSpeed = 0.125f;
    private Transform _playerTransform;
    public Vector3 offset;
    void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.LookAt(_playerTransform);
        transform.position = _playerTransform.position + offset;
    }
}
