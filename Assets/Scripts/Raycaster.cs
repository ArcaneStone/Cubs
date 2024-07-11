using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private DividedCube _splitCub;
    [SerializeField] private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.TryGetComponent<Cube>(out Cube cube))
                {
                    _splitCub.Split(cube);
                }
            }
        }
    }
}
