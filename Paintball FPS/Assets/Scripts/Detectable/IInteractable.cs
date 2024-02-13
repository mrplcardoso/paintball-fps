using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IDetectable
{
	public string hint { get; }
	public void Interact(GameObject interactor);
}
