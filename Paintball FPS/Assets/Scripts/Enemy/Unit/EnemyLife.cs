using UnityEngine;

[RequireComponent (typeof(EnemyColor))]
public class EnemyLife : MonoBehaviour, IDamageble
{
	EnemyColor color;

	void Awake()
	{
		color = GetComponent<EnemyColor>();
	}

	public void Damage(float damage, AvailableColors.ColorTag incomingColor)
	{
		if(color.color == incomingColor)
		{ gameObject.SetActive(false); }
	}
}