using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.SceneCamera;

public class Gun : MonoBehaviour, IWeapon
{
	public AvailableColors.ColorTag color { get; private set; }

	Renderer[] renderers;
	Cannon cannon;

	private void Awake()
	{
		renderers = GetComponentsInChildren<Renderer>();
		cannon = GetComponentInChildren<Cannon>();
	
		int r = Random.Range(0, (int)AvailableColors.ColorTag.Count);
		SetColor((AvailableColors.ColorTag)r);
	}

	public void SetColor(AvailableColors.ColorTag color)
	{
		this.color = color;
		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].material.color = AvailableColors.colorMap[color];
		}
	}
	
	public void Trigger(GameObject parent, string mask)
	{
		Vector3 target;
		if (Physics.Raycast(parent.transform.position, parent.transform.forward, out RaycastHit hit, 50f))
		{ target = hit.point; }
		else
		{ target = parent.transform.position + parent.transform.forward * 50f; }

		cannon.Shoot(color, target, mask);
	}
}
