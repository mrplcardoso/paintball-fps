using UnityEngine;

public class PaintableMeshAll : MonoBehaviour, IPaintable
{
	Renderer[] renderers;

	private void Awake()
	{
		renderers = GetComponentsInChildren<Renderer>();
	}

	public void SetColor(AvailableColors.ColorTag color)
	{
		for (int i = 0; i < renderers.Length; i++)
		{
			renderers[i].material.color = AvailableColors.colorMap[color];
		}
	}
}