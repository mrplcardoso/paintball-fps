using Utility.FSM;
using Utility.EventCommunication;
using Utility.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateGame : AbstractState
{
	List<IUpdatable> _updatables;
	bool update;

	void Awake()
	{
		_updatables = new List<IUpdatable>();
		EventHub.Subscribe(EventList.AddUpdate, OnAddUpdate);
	}

	void EnterPause()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_machine.Next<PauseGame>(0);
		}
	}

	private void Update()
	{
		if (!update) { return; }

		for (int i = 0; i < _updatables.Count; i++)
		{
			if (_updatables[i].isActive)
			{ _updatables[i].FrameUpdate(); }
		}

		EnterPause();
	}

	private void FixedUpdate()
	{
		if (!update) { return; }

		for (int i = 0; i < _updatables.Count; i++)
		{
			if (_updatables[i].isActive)
			{ _updatables[i].PhysicsUpdate(); }
		}
	}

	private void LateUpdate()
	{
		if (!update) { return; }

		for (int i = 0; i < _updatables.Count; i++)
		{
			if (_updatables[i].isActive)
			{ _updatables[i].PostUpdate(); }
		}
	}

	public override IEnumerator Enter(AbstractMachine machine)
	{
 		_machine = machine;
		update = true;
		Time.timeScale = 1;
		yield return null;
	}

	public override IEnumerator Exit()
	{
		yield return null;
		Time.timeScale = 0;
		update = false;
	}

	void OnAddUpdate(EventData data)
	{
		if (data.eventInformation is IUpdatable up)
		{
			if (!_updatables.Contains(up))
			{ _updatables.Add(up); }
		}
	}
}