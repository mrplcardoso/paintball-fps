using Utility.FSM;

public class GameManager : AbstractMachine
{
	public void Start()
	{
		Next<StartGame>(0.1f);
	}
}