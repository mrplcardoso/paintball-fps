using UnityEngine;

[RequireComponent (typeof(EnemyColor))]
public class EnemyLife : MonoBehaviour, IDamageble
{
	EnemyColor color;
	public GunItem gunItem;

	void Awake()
	{
		color = GetComponent<EnemyColor>();
	}

	public void Damage(float damage, AvailableColors.ColorTag incomingColor)
	{
		if(color.color == incomingColor)
		{
			Instantiate(gunItem, transform.position, Quaternion.identity);
			gameObject.SetActive(false);
		}
	}
}