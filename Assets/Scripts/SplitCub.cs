using UnityEngine;

public class SplitCub : MonoBehaviour
{
    [SerializeField] private SpawnerNewCub _spawnerNewCube;
    [SerializeField] private Explosion _explosion;

    private float _chance = 100f;

    private float _upperLimitChance = 101f;
    private float _lowerLimitChance = 0;

    private int _lowerLimitCubs = 2;
    private int _upperLimitCubs = 7;

    public void Split(GameObject cubeToSplit)
    {
        Vector3 cubePosition = cubeToSplit.transform.position;
        Vector3 cubeScale = cubeToSplit.transform.localScale;

        Destroy(cubeToSplit);

        if(Random.Range(_lowerLimitChance, _upperLimitChance) <= _chance)
        {
            int numberOfCubes = Random.Range(_lowerLimitCubs, _upperLimitCubs);

            for (int i = 0; i < numberOfCubes; i++)
            {
                _spawnerNewCube.Spawn(cubePosition);
            }

            _chance /= 2f;
        }

        _explosion.ApplyForce(cubePosition);
    }
}
