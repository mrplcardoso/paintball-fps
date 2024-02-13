using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
	NavMeshAgent agent;
	UnitAttributes attributes;

	Vector3 target { get { return PlayerUnit.player.body.position; } }
	float closeRange = 2;
	bool inRange { get { return (transform.position - target).magnitude <= closeRange; } }
	
	void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		attributes = GetComponentInChildren<UnitAttributes>();
	}

	void Start()	
	{
		agent.speed = attributes[AttributeType.Speed];
	}

	void Update()
	{
		if(inRange) { agent.SetDestination(transform.position); return; }

		agent.SetDestination(target);
	}
}
