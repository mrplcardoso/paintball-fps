using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEquipmentHolder
{
	public IEquipable equip { get; }
	public Transform transform { get; }
}
