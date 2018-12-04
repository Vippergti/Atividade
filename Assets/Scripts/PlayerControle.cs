using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControle : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float JumpForce = 1500;
    private Animator anim;

    float tiro;

    //float Speed = 2;

    public GameObject tiro1anim;// tipo de tiro
    public GameObject tiro2anim;//tipo de tiro


    public Image tiro1;   // referentes as UIS das armas 
    public Image tiro2;

    int armaatual;   // arma que está sendo usada

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        armaatual = 1;

        //Vector2 posicao1 = new Vector2(-3f, -2.5f);// posicao tiro

        //  Instantiate(tiro1anim, transform.position, Quaternion.identity); // instanciar tiro
        // Instantiate(tiro2anim, posicao2, Quaternion.identity);




    }


    void Update()
    {

        rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb2d.velocity.y); // movimentacao

        anim.SetBool("run", Input.GetAxis("Horizontal") != 0);



        if (Input.GetButtonDown("Jump"))// pulo com barra de espaco
        {
            rb2d.AddForce(new Vector2(0, JumpForce));
            anim.SetTrigger("jump");


        }
        ///////////////////////////////////////////////////////////////////////////
        if (Input.GetButtonDown("Fire1")) // tiro com ctrl Fire1
        {

            anim.SetTrigger("tiro");    //animacão tiro
            tiro = Time.time;


            if (armaatual == 1)   // define o tiro de acordo com a arma selecionada
            {
                GameObject novoTiro = Instantiate(tiro1anim, transform.position, Quaternion.identity);
                Rigidbody2D rbNovoTiro = novoTiro.GetComponent<Rigidbody2D>();
                rbNovoTiro.velocity = new Vector2(speed * 2, 0);

            }
            else
            {
                if (armaatual == 2)
                {
                    // Instantiate(tiro2anim, transform.position, Quaternion.identity);

                    GameObject novoTiro = Instantiate(tiro2anim, transform.position, Quaternion.identity);
                    Rigidbody2D rbNovoTiro = novoTiro.GetComponent<Rigidbody2D>();
                    rbNovoTiro.velocity = new Vector2(speed * 2, 0);
                    
                }
            }

        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) // define qual arma será utilizada
        {
            armaatual++;

            if (armaatual > 2)
            {
                armaatual = 1;
            }
        }



        if (Time.time > tiro + 0.20f)
        {
            anim.SetBool("tiro", false);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) // para definir qual arma está selecionada
        {
            if (tiro1.gameObject.activeSelf)
            {
                tiro2.gameObject.SetActive(true);
                tiro1.gameObject.SetActive(false);
                //  Instantiate(tiro1anim, transform.position, Quaternion.identity); // tipo de tiro

            }
            else
            {
                tiro2.gameObject.SetActive(false);
                tiro1.gameObject.SetActive(true);
                //  Instantiate(tiro2anim, transform.position, Quaternion.identity); // tipo de tiro
            }

        }
    }

        void OnCollisionEnter2D(Collision2D collision) // informa que está colidindo com o inimigo
    {

            if (collision.gameObject.tag == "Inimigo")
            {

                Destroy(gameObject);
            }

        //if (collision.gameObject.tag == "Player")
          // {
            //Destroy(gameObject);
        //}

    }

    }


    


