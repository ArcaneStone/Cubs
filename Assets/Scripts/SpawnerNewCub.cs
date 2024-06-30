using UnityEngine;

public class SpawnerNewCub : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    public float SpawnRadius;

    public void Spawn(Vector3 position)
    {
        Vector3 randomSpawnPosition = Random.insideUnitSphere * SpawnRadius + position;

        GameObject newCube = Instantiate(_cubePrefab, randomSpawnPosition, Quaternion.identity);

        newCube.transform.localScale /= 2;
        newCube.GetComponent<Renderer>().material.color = Random.ColorHSV();
        newCube.tag = "Cube";

        Rigidbody rb = newCube.GetComponent<Rigidbody>();

        if (rb == null)
        {
            rb = newCube.AddComponent<Rigidbody>();        
        }
    }
}
