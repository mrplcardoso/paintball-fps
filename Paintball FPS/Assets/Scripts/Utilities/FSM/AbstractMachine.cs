using System.Collections;
using UnityEngine;

namespace Utility.FSM
{
	public abstract class AbstractMachine : MonoBehaviour
	{
		[SerializeField] AbstractState _currentState;
		bool transitioning;

		public void Next<T>(float interval) where T : AbstractState
		{
			StartCoroutine(Transition<T>(interval));
		}

		IEnumerator Transition<T>(float interval) where T : AbstractState
		{
			if (transitioning) { yield break; }

			if(_currentState != null) 
			{ yield return _currentState.Exit(); }

			yield return new WaitForSeconds(interval);

			_currentState = GetComponent<T>();
			yield return _currentState.Enter(this);
		}
	}
}