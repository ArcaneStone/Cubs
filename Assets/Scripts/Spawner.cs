using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _spawnRadius = 5f;
    private float _divider = 2f;

    public void SetSpawnRadius(float radius)
    {
        _spawnRadius = radius;
    }

    public void Spawn(Vector3 position)
    {
        Vector3 randomSpawnPosition = Random.insideUnitSphere * _spawnRadius + position;

        Cube newCube = Instantiate(_cubePrefab, randomSpawnPosition, Quaternion.identity);

        newCube.transform.localScale /= _divider;
        newCube.SetRandomColour();        
    }
}
