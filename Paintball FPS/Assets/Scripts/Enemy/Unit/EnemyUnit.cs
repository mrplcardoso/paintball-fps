using UnityEngine;
using Utility.Unit;
using Utility.EventCommunication;

public class EnemyUnit : UnitObject
{
	public EnemyColor color { get; private set; }

	private void Awake()
	{
		color = GetComponent<EnemyColor>();
	}

	void Start()
	{
		EventHub.Publish(EventList.AddUpdate, new EventData(this));
	}

	public override void FrameUpdate()
	{
		if (FrameAction != null)
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
