using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SplitCub _splitCub;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("Cube"))
                {
                    _splitCub.Split(hit.collider.gameObject);
                }
            }
        }
    }
}
