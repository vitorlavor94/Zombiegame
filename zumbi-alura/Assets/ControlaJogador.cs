using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour{


    public float Velocidade = 10;  
    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGamerOver;
    public bool Vivo = true;

    private void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
       float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ );

        
        //puxa o componente Rigidbody e coloca como posição o modo de se mover


       //transform.Translate(direcao * Velocidade * Time.deltaTime);
       //metodo de se mover por segundo

       if(direcao != Vector3.zero)
       {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }
        if(Vivo == false)
        {
            if(Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene("game");
                }
        }
        //transform.Translate(Vector3.right);
        //transform.Translate(Vector3.left);
       // transform.Translate(Vector3.back;
       // transform.Translate(Vector3.down);
      //  transform.Translate(Vector3,up);
    }
    void FixedUpdate()
        {

        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Velocidade * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impacto;

        if(Physics.Raycast(raio, out impacto, 100, MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);

            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }

        }
}
