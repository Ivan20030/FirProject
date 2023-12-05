using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField]
    private float _movementOffset;
    [SerializeField]
    [Min(0.0f)]
    private float _movementSpeed;
    [SerializeField]
    [Min(0.0f)]
    private float _rotateSpeed;
    
    private float _minY, _maxY;
    private Vector3 _direction = Vector3.up;

    void Start()
    {
        _minY = transform.position.y - _movementOffset;
        _maxY = transform.position.y + _movementOffset;
    }

    void Update()
    {
        if (transform.position.y > _maxY) _direction = Vector3.down;
        else if (transform.position.y < _minY) _direction = Vector3.up;

        transform.Translate(_direction * _movementSpeed * Time.deltaTime, Space.World);
        transform.Rotate(Vector3.right * _rotateSpeed * Time.deltaTime, Space.Self);
    }
}
