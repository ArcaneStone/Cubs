using System.Collections.Generic;
using UnityEngine;

public class DividedCube : MonoBehaviour
{
    [SerializeField] private Spawner _spawnerNewCube;
    [SerializeField] private Explosion _explosion;

    private float _chance = 100f;

    private float _upperLimitChance = 101f;
    private float _lowerLimitChance = 0;
    private float _divider = 2f;

    private int _lowerLimitCubs = 2;
    private int _upperLimitCubs = 7;

    private List<Cube> _newCubes = new List<Cube>();

    public void Split(Cube cubeToSplit)
    {
        Vector3 cubePosition = cubeToSplit.transform.position;

        if (cubeToSplit != null)
        {
            if (Random.Range(_lowerLimitChance, _upperLimitChance) <= _chance)
            {
                int numberOfCubes = Random.Range(_lowerLimitCubs, _upperLimitCubs);

                for (int i = 0; i < numberOfCubes; i++)
                {
                    Cube newCube = _spawnerNewCube.Spawn(cubePosition, cubeToSplit.transform.localScale / _divider);
                    _newCubes.Add(newCube);
                }

                _chance /= _divider;
                Destroy(cubeToSplit.gameObject);
            }
            else
            {
                _explosion.Expload(cubeToSplit);
                Destroy(cubeToSplit.gameObject);
            }
        }
    }
}
