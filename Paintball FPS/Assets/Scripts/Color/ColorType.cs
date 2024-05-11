using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ColorType
{
	public Color color { get { return _color; } }
	[SerializeField] private Color _color;

	public string name { get { return _name; } }
	[SerializeField] private string _name;
}
