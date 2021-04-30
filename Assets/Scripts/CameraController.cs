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
        Vector3 desiredPosition = _playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position,desiredPosition,smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(_playerTransform);

    }
}
