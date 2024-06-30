using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private SpawnerNewCub _spawnerNewCub;

    public void ApplyForce(Vector3 point)
    {
        Collider[] colliders = Physics.OverlapSphere(point, _spawnerNewCub.SpawnRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if(rb != null)
            {
                rb.AddExplosionForce(_force, point, _spawnerNewCub.SpawnRadius);
            }
        }
    }
}
