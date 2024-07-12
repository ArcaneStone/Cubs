using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _force;

    private float _explosionRadius = 3f;

    public void ApplyForce(Vector3 point, List<Cube> newCubes)
    {
        Collider[] colliders = Physics.OverlapSphere(point, _explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null && newCubes.Contains(hit.GetComponent<Cube>()))
            {
                rigidbody.AddExplosionForce(_force, point, _explosionRadius);
            }
        }
    }
}
