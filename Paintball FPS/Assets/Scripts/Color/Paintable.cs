using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    Renderer renderer;
    Material splash { get { return renderer.materials[1]; } }
    Vector3 size;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        size = renderer.bounds.size;
        splash.SetColor("_splashColor", renderer.materials[0].color);
    }

    public void Paint(Color color, Vector2 position, Vector3 size)
    {
        Vector2 pos = Vector2.zero;
        pos.x = position.x - transform.position.x;
        pos.y = position.y - transform.position.y;
        pos.x = (pos.x / this.size.x) - 0.5f;
        pos.y = (pos.y / this.size.y) - 0.5f;

        float s = size.magnitude / this.size.magnitude;
        print(s);

        splash.SetVector("_uvOffset", pos);
        splash.SetColor("_splashColor", color);
        splash.SetFloat("_size", s);
    }
}