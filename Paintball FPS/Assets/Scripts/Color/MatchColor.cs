using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchColor : MonoBehaviour
{
	public ColorType color { get { return _color; } }
	[SerializeField] ColorType _color;
}
