using UnityEngine;
using Utility.Unit;
using Utility.EventCommunication;

public class PlayerUnit : UnitObject
{
	public static PlayerUnit player { get; private set; }
	public PlayerShoot shoot { get; private set; }
	public Transform body { get; private set; }
	public AvailableColors.ColorTag color => shoot.weaponHand.color;

	void Awake()
	{
		player = this;
		body = GetComponentInChildren<PlayerMove>().transform;
		shoot = GetComponent<PlayerShoot>();
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
