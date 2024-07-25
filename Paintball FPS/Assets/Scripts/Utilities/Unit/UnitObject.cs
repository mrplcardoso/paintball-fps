using System;
using Utility.Actions;
using UnityEngine;

namespace Utility.Unit
{
	public abstract class UnitObject : MonoBehaviour, IUpdatable
	{
		public Action FrameAction;
		public Action PhysicsAction;
		public Action PostAction;

		public bool isActive { get { return gameObject.activeInHierarchy; } }

		public abstract void FrameUpdate();
		public abstract void PhysicsUpdate();
		public abstract void PostUpdate();
	}
}