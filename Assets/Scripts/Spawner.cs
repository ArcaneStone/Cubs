using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Cube _cubePrefab;

    private float _spawnRadius = 5f;

    public void SetSpawnRadius(float radius)
    {
        _spawnRadius = radius;
    }

    public Cube Spawn(Vector3 position, Vector3 scale)
    {
        Vector3 randomSpawnPosition = Random.insideUnitSphere * _spawnRadius + position;

        Cube newCube = Instantiate(_cubePrefab, randomSpawnPosition, Quaternion.identity);

        newCube.transform.localScale = scale;
        newCube.SetRandomColour();

        return newCube;
    }
}
