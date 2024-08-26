using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour, IInteractable
{
	[SerializeField] Gun prefab;

	public void Interaction(GameObject interactor)
	{
		if(prefab == null) { Debug.LogError("Gun prefab was not attached in Inspector"); }

		//TryGetComponent from "interactor" (player, in this case)
		if (interactor.TryGetComponent(out IEquipSlot slot))
		{
			//Pass gun prefab as argument to be equiped
			slot.Equip(prefab);
			Destroy(gameObject);
		}
	}
}
