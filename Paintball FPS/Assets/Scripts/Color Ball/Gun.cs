using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IColored
{
	public AvailableColors.ColorTag color { get; private set; }

	Renderer[] renderers;
	Cannon cannon;

	private void Awake()
	{
		renderers = GetComponentsInChildren<Renderer>();
		cannon = GetComponentInChildren<Cannon>();
	}

	public void SetColor(AvailableColors.ColorTag color)
	{
		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].material.color = AvailableColors.colorMap[color];
		}
	}
	
	public void Shoot(AvailableColors.ColorTag color, Vector3 target)
	{
		cannon.Shoot(color, target);
	}
}
