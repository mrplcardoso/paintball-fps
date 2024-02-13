using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAttributes : MonoBehaviour
{
	[SerializeField] AttributeDatabase database;
	Dictionary<AttributeType, AttributeEntry> table;
	public float this[AttributeType type] => table[type].averageValue;

	private void Awake()
	{
		Load();
	}

	private void Load()
	{
		table = database.LoadTable();
	}
}
