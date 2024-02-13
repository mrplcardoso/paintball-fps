using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipable
{
	public Transform transform { get; }
	public Collider collider { get; }
	public Vector3 equipRotation { get; }
	public float yDropPosition { get; }

	public void Equip(IEquipmentHolder holder);
	public void DeEquip(IEquipmentHolder holder);
}
