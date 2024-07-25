using Utility.FSM;
using System.Collections;

public class StartGame : AbstractState
{
	public override IEnumerator Enter(AbstractMachine machine)
	{
		_machine = machine;
		yield return null;
		_machine.Next<UpdateGame>(0);
	}
}