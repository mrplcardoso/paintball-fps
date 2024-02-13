using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponHolder : IEquipmentHolder
{
	Weapon currentWeapon { get; }
	
	void UseWeapon();
	void StopWeapon();
}
