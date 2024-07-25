using UnityEngine;

public class EnemyColor : MonoBehaviour, IColored
{
	[SerializeField] MeshRenderer meshRenderer;
	public AvailableColors.ColorTag color { get; private set; }

	void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	public void SetColor(AvailableColors.ColorTag color)
	{
		this.color = color;
		//Modifica a cor do modelo 3d a partir do ColorTag
		meshRenderer.material.color = AvailableColors.colorMap[color];
	}
}