﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien: MonoBehaviour
{

    
    //private Rigidbody2D rb; // para possibilitar aplicar uma força
    //private Animator anim;
        

    // Use this for initialization
    void Start()
    {
        //rb = gameObject.GetComponent<Rigidbody2D>(); // variavel recebendo componente do gameobject
        //anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

   /*void OnCollisionEnter2D(Collision2D collision) // informa que está colidindo com o tiro
       {
          if (other.gameObject.CompareTag("inimigo"))
          if (collision.gameObject.tag == "tiro")

       {
            Destroy(gameObject);


       }*/

    void OnTriggerEnter2D(Collider2D col) // informa que está colidindo com o inimigo
        {
            if (col.gameObject.tag == "tiro1")
            {
                Destroy(gameObject);


            }
        }
    }



