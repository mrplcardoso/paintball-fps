using UnityEngine;

public class BallCollision : MonoBehaviour, IColored
{
	MeshRenderer meshRenderer;
	[SerializeField] float damage;

	public AvailableColors.ColorTag color { get; private set; }

	void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
	}

	public void SetColor(AvailableColors.ColorTag color)
	{
		this.color = color;
		meshRenderer.material.color = AvailableColors.colorMap[color];
	}

	//Fun��o chamada quando um objeto COM RIGIDBODY ENTRA
	//EM COLIS�O com outro.
	private void OnCollisionEnter(Collision collision)
	{
		GameObject incoming = collision.gameObject;
		//'collision' � o objeto que armazena as informa��es de colis�o
		//no caso, 'collision.gameObject' acessa o objeto que est� colidindo com a bola.
		IDamageble damageble = incoming.GetComponent<IDamageble>();
		if(damageble != null)
		{
			//Se o objeto colidido implementa a interface IDamageble,
			//n�o impora qualquer seja o objeto, ele sofrer� dano da bala
			//sem a necessidade dela saber quem � o objeto.
			//O segundo par�metro � a cor da bola.
			damageble.Damage(damage, color);
		}

		IPaintable paintable = incoming.GetComponent<IPaintable>();
		if(paintable != null)
		{ paintable.SetColor(color); }

		BallCollision other = incoming.GetComponent<BallCollision>();
		if(other != null)
		{
			if (other.color != color)
			{
				//Como a bola tem Rigidbody, ao colidir com outra bola, se elas n�o forem destru�das
				//o pr�prio Rigidbody ir� calcular o ricochete.
				//Funciona apenas em Rigidbody 'dynamic' (n�o � est�tico nem cinem�tico).
				return;
			}
		}

		gameObject.SetActive(false);
	}
}