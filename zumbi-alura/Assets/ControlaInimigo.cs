using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    // Start is called before the first frame update
   
   public GameObject Jogador;
   public float Velocidade = 5;

   void Start () {
       Jogador = GameObject.FindWithTag("Jogador");
       int geraTipoZumbi = Random.Range(1, 28);
       transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
   }

    // Update is called once per frame
  void FixedUpdate()
{
    float distancia = Vector3.Distance(transform.position, Jogador.transform.position);

    Vector3 direcao = Jogador.transform.position - transform.position;

    Quaternion novaRotacao = Quaternion.LookRotation(direcao);
    GetComponent<Rigidbody>().MoveRotation(novaRotacao);

    if (distancia > 2.5)
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * Velocidade * Time.deltaTime);

        GetComponent<Animator>().SetBool("Atacando", false);
    }
    else
    {
        GetComponent<Animator>().SetBool("Atacando", true);
    }
}
    void AtacaJogador ()
    {
        Time.timeScale = 0;
        Jogador.GetComponent<ControlaJogador>().TextoGamerOver.SetActive(true);
        Jogador.GetComponent<ControlaJogador>().Vivo = false;

    }
}