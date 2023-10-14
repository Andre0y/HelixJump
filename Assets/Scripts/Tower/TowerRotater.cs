using UnityEngine;

public class TowerRotater : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;

    private const string CurrentAxis = "Mouse X";

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            float horizontalInput = Input.GetAxis(CurrentAxis);
            float angle = -horizontalInput * _rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, angle);
        }
    }
}
