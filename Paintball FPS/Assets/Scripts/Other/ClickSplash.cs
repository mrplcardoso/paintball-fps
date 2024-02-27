using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.Random;

public class ClickSplash : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                Vector3 size = hit.collider.GetComponent<Renderer>().bounds.size;
                Material m = hit.collider.GetComponent<Renderer>().materials[1];

                Vector2 pos = Vector2.zero;
                pos.x = hit.point.x - hit.collider.transform.position.x;
                pos.y = hit.point.y - hit.collider.transform.position.y;
                pos.x = (pos.x / size.x) - 0.5f;
                pos.y = (pos.y / size.y) - 0.5f;
                m.SetVector("_uvOffset", pos);

                Color c = Color.white;
                c.r = RandomStream.NextFloat(0f, 1f);
                c.g = RandomStream.NextFloat(0f, 1f);
                c.b = RandomStream.NextFloat(0f, 1f);

                m.SetColor("_splashColor", c);
            }
        }
    }
}
