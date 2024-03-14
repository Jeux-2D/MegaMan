using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Gestion de d�placement et du saut du personnage � l'aide des touches : a, d et w������
* Gestion des d�tections de collision entre le personnage et les objets du jeu��
* Par: Vahik Toroussian
* Modifi�: 5/12/2018
*/
public class ControlerPersonnage : MonoBehaviour
{
    float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale d�sir�e
    float vitesseY;      //vitesse verticale 
    public float vitesseSaut;   //vitesse de saut d�sir�e

    /* D�tection des touches et modification de la vitesse de d�placement;
       "a" et "d" pour avancer et reculer, "w" pour sauter
    */
    void Update()
    {
        // d�placement vers la gauche
        if (Input.GetKey("a"))
        {
            vitesseX = -vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (Input.GetKey("d"))   //d�placement vers la droite
        {
            vitesseX = vitesseXMax;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            vitesseX = GetComponent<Rigidbody2D>().velocity.x;  //vitesse actuelle horizontale
        }

        // sauter l'objet � l'aide la touche "w"
        if (Input.GetKeyDown("w"))
        {
            vitesseY = vitesseSaut;
            GetComponent<Animator>().SetBool("saut", true);
        }
        else
        {
            vitesseY = GetComponent<Rigidbody2D>().velocity.y;  //vitesse actuelle verticale
        }

        //Applique les vitesses en X et Y
        GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


        //**************************Gestion des animaitons de course et de repos********************************
        //Active l'animation de course si la vitesse de d�placement n'est pas 0, sinon le repos sera jouer par Animator
        if (vitesseX > 0.1f || vitesseX < -0.1f)
        {
            GetComponent<Animator>().SetBool("marche", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("marche", false);
        }





    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Animator>().SetBool("saut", false);

    }
}
