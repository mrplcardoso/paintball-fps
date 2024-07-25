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

	//Função chamada quando um objeto COM RIGIDBODY ENTRA
	//EM COLISÃO com outro.
	private void OnCollisionEnter(Collision collision)
	{
		GameObject incoming = collision.gameObject;
		//'collision' é o objeto que armazena as informações de colisão
		//no caso, 'collision.gameObject' acessa o objeto que está colidindo com a bola.
		IDamageble damageble = incoming.GetComponent<IDamageble>();
		if(damageble != null)
		{
			//Se o objeto colidido implementa a interface IDamageble,
			//não impora qualquer seja o objeto, ele sofrerá dano da bala
			//sem a necessidade dela saber quem é o objeto.
			//O segundo parâmetro é a cor da bola.
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
				//Como a bola tem Rigidbody, ao colidir com outra bola, se elas não forem destruídas
				//o próprio Rigidbody irá calcular o ricochete.
				//Funciona apenas em Rigidbody 'dynamic' (não é estático nem cinemático).
				return;
			}
		}

		gameObject.SetActive(false);
	}
}