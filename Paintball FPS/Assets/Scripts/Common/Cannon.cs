using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
  [SerializeField] float force;
  /* Algoritmo - Disparo de proj�til */

  //1 - Ter o projetil a ser disparado
  //qualquer objeto que contenha o c�digo "ColorBall"
  //No caso, isso est� feito pelo BallPooler.

  public void Shoot(AvailableColors.ColorTag color)
  {
    //2 - Verifica, a cada frame, se � permitido disparar
    //No caso, nessa implementa��o, o objeto que dispara a arma,
    //por exemplo, o c�digo do jogador, � quem efetua essa verifica��o
    //e ai, se for permitido, � executada esse m�todo.

    //3 - Instanciar um clone do projetil (em cena)
    //4 - Posicionar projetil na ponta da arma
    //Instantiate criar uma instancia de um objeto,
    //em cena, em uma dada posi��o e rota��o
    ColorBall current = BallPooler.pooler.Next();
    if (current == null)
    { return; }

    current.transform.position = transform.position;
    current.collision.SetColor(color);
    current.gameObject.SetActive(true);
    current.Launch(transform.rotation, force);
  }
}
