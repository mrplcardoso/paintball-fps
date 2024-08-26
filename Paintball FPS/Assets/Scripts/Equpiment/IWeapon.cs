using UnityEngine;

public interface IWeapon : IEquipment, IColored
{
	public void Trigger(GameObject owner, string layer);
}