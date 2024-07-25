using System.Collections;
using UnityEngine;

namespace Utility.FSM
{
	public abstract class AbstractState : MonoBehaviour
	{
		protected AbstractMachine _machine;
		public AbstractMachine machine => _machine;

		public virtual IEnumerator Enter(AbstractMachine machine) { yield return null;  }
		public virtual IEnumerator Exit() {  yield return null; }
	}
}