using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetection : MonoBehaviour
{
	MeshRenderer _renderer;

	public Material outline { get { return _outline; } }
	[SerializeField] Material _outline;

	bool detecting;

	void Awake()
	{
		_renderer = GetComponentInChildren<MeshRenderer>();
		detecting = false;
	}

	public void ShowOutline()
	{
		if(detecting) { return; }
		
		Material[] original = GetComponent<Renderer>().materials;
		int length = original.Length;
		Material[] list = new Material[length + 1];

		for(int i = 0; i < length; ++i) { list[i] = original[i]; }
		list[length] = outline;
		
		GetComponent<Renderer>().materials = list;
		
		detecting = true;
	}

	public void HideOutline()
	{
		if(!detecting) { return; }
		
		Material[] original = GetComponent<Renderer>().materials;
		int length = original.Length;
		Material[] list = new Material[length - 1];

		for(int i = 0; i < length - 1; ++i) { list[i] = original[i]; }
		GetComponent<Renderer>().materials = list;
		
		detecting = false;
	}
}
