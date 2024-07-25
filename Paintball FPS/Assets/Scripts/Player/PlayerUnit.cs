using UnityEngine;
using Utility.Unit;
using Utility.EventCommunication;

public class PlayerUnit : UnitObject
{
	public static PlayerUnit player { get; private set; }
	public Transform body { get; private set; }

	void Awake()
	{
		player = this;
		body = GetComponentInChildren<PlayerMove>().transform;
	}

	void Start()
	{
		EventHub.Publish(EventList.AddUpdate, new EventData(this));
	}

	public override void FrameUpdate()
	{
		if(FrameAction != null)
		{ FrameAction(); }
	}

	public override void PhysicsUpdate()
	{
		if (PhysicsAction != null)
		{ PhysicsAction(); }
	}

	public override void PostUpdate()
	{
		if (PostAction != null)
		{ PostAction(); }
	}
}
