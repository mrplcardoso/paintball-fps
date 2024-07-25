using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
	private void Awake()
	{
		var transforms = GetComponentsInChildren<Transform>();
		for(int i = 0; i < transforms.Length; i++)
		{ transforms[i].gameObject.AddComponent<PaintableMeshAll>(); }
	}
}
