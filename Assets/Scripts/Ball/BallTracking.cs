using UnityEngine;

public class BallTracking : MonoBehaviour
{
    [SerializeField] private float _offsetMiltiplierAxisXZ;
    [SerializeField] private float _cameraOffsetY;

    private Ball _ball;
    private Beam _beam;
    private Vector3 _currentBallPosition;
    private Vector3 _minBallPosition;
    private Vector3 _cameraPosition;

    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _beam = FindObjectOfType<Beam>();

        _currentBallPosition = _ball.transform.position;
        _minBallPosition = _ball.transform.position;
    }

    private void Update()
    {
        _currentBallPosition = _ball.transform.position;

        if (_currentBallPosition.y < _minBallPosition.y)
        {
           Track();
            _minBallPosition = _currentBallPosition;
        }
    }

    private void Track()
    {
        Vector3 beamPosition = _beam.transform.position;
        beamPosition.y = _ball.transform.position.y;
        _cameraPosition = _ball.transform.position;
        Vector3 direction = (beamPosition - _ball.transform.position).normalized;
        _cameraPosition -= direction * _offsetMiltiplierAxisXZ;
        _cameraPosition.y += _cameraOffsetY;
        transform.position = _cameraPosition;
        transform.LookAt(_ball.transform);
    }
}
