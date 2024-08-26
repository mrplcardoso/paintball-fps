using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, IDamageble
{
	[SerializeField] Image lifeBar;

	readonly float max = 100;

	//Change "set" if bar has VFX
	float life { get { return current; } set { current = value; lifeBar.fillAmount = life / max; } }
	float current;

	void Start()
	{
		if (lifeBar == null) { Debug.LogError("Life Bar not defined in Inspector"); return; }

		life = max;
	}

	public void Damage(float damage, AvailableColors.ColorTag incomingColor)
	{
		life = Mathf.Clamp(life - damage, 0, max);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
		{ life -= 10; }

		if (Input.GetKeyDown(KeyCode.G))
		{ life += 10; }
	}
}
