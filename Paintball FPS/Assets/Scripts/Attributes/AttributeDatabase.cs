using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Attribute Database", menuName = "Scriptable Objects/Attribute Database", order = 4)]
public class AttributeDatabase : ScriptableObject
{
	[SerializeField] AttributeEntry[] entries;

	public Dictionary<AttributeType, AttributeEntry> LoadTable()
	{
		Dictionary<AttributeType, AttributeEntry> at = new();
		for(int i = 0; i < entries.Length; i++)
		{
			at.Add(entries[i].type, entries[i]);
		}

		return at;
	}
}
