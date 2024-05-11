using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemIdle : MonoBehaviour
{
	float angularSpeed = 5f;
	public bool inIdle { get { return transform.parent == null; } }

	void Update()
	{
		if(!inIdle) { return; }
		Idle();
	}
	
	void Idle()
	{
		transform.Rotate(0, angularSpeed * Time.deltaTime, 0);
	}
}
