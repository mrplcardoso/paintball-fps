using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoSelector : MonoBehaviour
{
	[SerializeField] Image selector;

	public AmmoCell[] ammos;
	AmmoCell current { get { return ammos[index % ammos.Length]; } }

	Dictionary<AvailableColors.ColorTag, int> cellMap;

	int index;

	private void Awake()
	{
		ammos = GetComponentsInChildren<AmmoCell>();
		
		cellMap = new();
		for(int i = 0; i < ammos.Length; i++) { cellMap.Add(ammos[i].color, i); }
	}

	void MoveSelector(Vector3 position)
	{
		position.z = selector.transform.position.z;
		position.y = selector.transform.position.y;
		selector.transform.position = position;
	}

	public AvailableColors.ColorTag Next()
	{
		index++;
		if(index >= ammos.Length) { index = 0; }

		MoveSelector(current.transform.position);

		return current.color;
	}

	public void Set(AvailableColors.ColorTag color)
	{
		index = cellMap[color];
		MoveSelector(current.transform.position);
	}

	public void Consume(string value)
	{
		current.ammoText.text = value;
	}
}
