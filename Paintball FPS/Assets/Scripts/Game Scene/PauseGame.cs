using Utility.FSM;
using System.Collections;
using UnityEngine;
using Utility.Actions;

public class PauseGame : AbstractState
{
	[SerializeField] GameObject pauseWindow;
	bool pause;

	private void Awake()
	{
		pause = false;
	}

	IEnumerator ExitPause()
	{
		yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Escape));

		_machine.Next<UpdateGame>(0);
	}

	public override IEnumerator Enter(AbstractMachine machine)
	{
		_machine = machine;
		pause = true;
		StartCoroutine(ExitPause());
		yield return null;
		pauseWindow.SetActive(true);
	}

	public override IEnumerator Exit()
	{
		pauseWindow.SetActive(false);
		yield return null;
		pause = false;
		_machine.Next<UpdateGame>(0);
	}
}