using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDetectable
{
	public GameObject gameObject { get; }
	public Material outline { get; }
    public string name { get; }
	public string description { get; }
	
	public void InDetection();
	public void OutDetection();
}

