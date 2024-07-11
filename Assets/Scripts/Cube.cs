using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{    
    private Renderer _renderer;

    public void SetRandomColour()
    {
        _renderer.material.color = Random.ColorHSV();
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
}
