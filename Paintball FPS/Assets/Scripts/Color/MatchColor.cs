using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchColor : MonoBehaviour
{
	[SerializeField] ColorType _type;
	
	public Color color { get { return _type.color; } }
	public string name { get { return _type.name; } }
}
