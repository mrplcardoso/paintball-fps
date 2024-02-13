using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AttributeEntry
{
	public AttributeType type;
	public float averageValue;
	public float minValue, maxValue;
}
