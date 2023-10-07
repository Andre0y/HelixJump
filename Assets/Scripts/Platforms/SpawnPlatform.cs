using UnityEngine;

public class SpawnPlatform : Platform
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;

    private void Start()
    {
        BallSpawn();
    }

    private void BallSpawn()
    {
        Instantiate(_ball, _spawnPoint.position, Quaternion.identity);
    }

}

