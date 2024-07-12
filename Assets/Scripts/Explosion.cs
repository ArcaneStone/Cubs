using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _forceMultiplier;

    private float _explosionRadius = 50f;
    private float _numberDefinitionOfCoefficient = 1f;

    public void Expload(Cube cube)
    {
        float explosionRadius = _explosionRadius * (_numberDefinitionOfCoefficient / cube.transform.lossyScale.x);

        Collider[] colliders = Physics.OverlapSphere(cube.transform.position, explosionRadius);

        foreach (Collider hit in colliders)
        {
            Rigidbody rigidbody = hit.GetComponent<Rigidbody>();

            if (rigidbody != null)
            {
                float distance = Vector3.Distance(cube.transform.position, hit.transform.position);
                float force = _forceMultiplier * (_numberDefinitionOfCoefficient / cube.transform.localScale.x)
                                * (_numberDefinitionOfCoefficient - (distance / explosionRadius));

                rigidbody.AddExplosionForce(force, cube.transform.position, explosionRadius);
            }
        }
    }
}
