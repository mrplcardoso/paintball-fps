using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
  [SerializeField] float force;
  /* Algoritmo - Disparo de projétil */

  //1 - Ter o projetil a ser disparado
  //qualquer objeto que contenha o código "ColorBall"
  //No caso, isso está feito pelo BallPooler.

  public void Shoot(AvailableColors.ColorTag color)
  {
    //2 - Verifica, a cada frame, se é permitido disparar
    //No caso, nessa implementação, o objeto que dispara a arma,
    //por exemplo, o código do jogador, é quem efetua essa verificação
    //e ai, se for permitido, é executada esse método.

    //3 - Instanciar um clone do projetil (em cena)
    //4 - Posicionar projetil na ponta da arma
    //Instantiate criar uma instancia de um objeto,
    //em cena, em uma dada posição e rotação
    ColorBall current = BallPooler.pooler.Next();
    if (current == null)
    { return; }

    current.transform.position = transform.position;
    current.collision.SetColor(color);
    current.gameObject.SetActive(true);
    current.Launch(transform.rotation, force);
  }
}
