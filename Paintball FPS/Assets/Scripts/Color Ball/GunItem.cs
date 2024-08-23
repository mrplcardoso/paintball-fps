using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour, IInteractable
{
	[SerializeField] Gun prefab;

	public void Interaction(GameObject interactor)
	{
		if(prefab == null)
		{ Debug.LogError("Gun prefab was not attached in Inspector"); }

		//To do
		/* - Get component responsible for gun equip, from 'interactor' */
		/* - Call method responsible for equip and pass gun prefab as argument */
	}
}
