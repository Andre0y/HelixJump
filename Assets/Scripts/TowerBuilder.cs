using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private float _levelCount;
    [SerializeField] private float _extraSize;
    [SerializeField] private GameObject _beam;
    [SerializeField] private SpawnPlatform _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;

    [SerializeField] private Platform[] _platforms;

    private void Start()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, _levelCount / 2 + _extraSize, 1);

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y;

        SpawnSpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);
        SpawnFinishPlatform(_finishPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
            SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, beam.transform);
        }
    }

    private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
        spawnPosition.y -= 1;
    }

    private void SpawnFinishPlatform(FinishPlatform finishPlatform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(finishPlatform, spawnPosition, Quaternion.Euler(0, 0, 0), parent);
        spawnPosition.y = _beam.transform.position.y;
    }

    private void SpawnSpawnPlatform(SpawnPlatform spawnPlatform, ref Vector3 spawnPosition, Transform parent)
    {
        Instantiate(spawnPlatform, spawnPosition, Quaternion.Euler(0, 0, 0), parent);
        spawnPosition.y *= -1;
    }
}
