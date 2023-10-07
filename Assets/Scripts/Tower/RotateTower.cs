using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class RotateTower : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.tapCount >= 0)
        {
            if(touch.phase == TouchPhase.Moved)
            {
                float torque = Time.deltaTime * _rotateSpeed * touch.deltaPosition.x;
                _rigidbody.AddTorque(Vector3.up * -torque);
            }
        }
    }
}
