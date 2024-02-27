using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SplashParticle : MonoBehaviour
{
    VisualEffect vfx;

    void Awake()
    {
        vfx = GetComponent<VisualEffect>();
        vfx.Stop();
    }

    public void SetColor(Color color)
    {
        vfx.SetVector4("color", color);
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
        vfx.Play();
    }
}
