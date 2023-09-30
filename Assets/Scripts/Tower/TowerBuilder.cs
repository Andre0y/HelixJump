using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _levelCount;
    [SerializeField] private float _extraSize;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;

    [SerializeField] private Platform[] _platforms;

    private float _startAndFinishExtraSize = 0.5f;
    private float _beamSizeY => _levelCount / 2 + _startAndFinishExtraSize + _extraSize / 2f;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, _beamSizeY, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _extraSize;

        SpawnPlatform(_spawnPlatform, ref spawnPosition, 0f, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, Random.Range(0, 360), beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, 0f, beam.transform);
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, float rotationDegrees, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, rotationDegrees, 0), parent);
        spawnPosition.y -= 1;
    }
}
