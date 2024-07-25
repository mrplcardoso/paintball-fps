using UnityEngine;

public interface IColored
{
	public AvailableColors.ColorTag color { get; }
	public void SetColor(AvailableColors.ColorTag color);
}