namespace Utility.Actions
{
	public interface IUpdatable
	{
		public bool isActive { get; }
		void FrameUpdate();
		void PhysicsUpdate();
		void PostUpdate();
	}
}