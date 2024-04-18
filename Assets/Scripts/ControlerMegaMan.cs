using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Gestion de déplacement et du saut du personnage à l'aide des touches : a, d et w      
* Gestion des détections de collision entre le personnage et les objets du jeu  
* Par: Vahik Toroussian
* Modifié: 5/12/2018
*/
public class ControlerPersonnage : MonoBehaviour
{
    float vitesseX;      //vitesse horizontale actuelle
    public float vitesseXMax;   //vitesse horizontale Maximale désirée
    float vitesseY;      //vitesse verticale 
    public float vitesseSaut;   //vitesse de saut désirée

    public AudioClip sonMort;   //Son de mort de Megaman

    private bool estMort;   //Variable qui determine si Megaman est mort
    private bool peutAttaquer = true;  //Variable qui determine si Megaman peut attaquer
    public float vitesseMax;   //Vitesse max du dash

    public GameObject abeille;  //GameObject de l'ennemis abeille
    public GameObject abeilleDeplacement;   //Gaemobject de son déplacmeent

    /* Détection des touches et modification de la vitesse de déplacement;
       "a" et "d" pour avancer et reculer, "w" pour sauter
    */
    void Update()
    {
        if (!estMort)
        {
            // déplacement vers la gauche
            if (Input.GetKey("a"))
            {
                vitesseX = -vitesseXMax;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetKey("d"))   //déplacement vers la droite
            {
                vitesseX = vitesseXMax;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                vitesseX = GetComponent<Rigidbody2D>().velocity.x;  //vitesse actuelle horizontale
            }

            // sauter l'objet à l'aide la touche "w"
            if (Input.GetKeyDown("w") && Physics2D.OverlapCircle(transform.position, 0.25f))
            {
                vitesseY = vitesseSaut;
                GetComponent<Animator>().SetBool("saut", true);
            }
            else
            {
                vitesseY = GetComponent<Rigidbody2D>().velocity.y;  //vitesse actuelle verticale
            }

            // attaque avec la touche "espace"
            if (Input.GetKeyDown(KeyCode.Space) && peutAttaquer == true)
            {
                peutAttaquer = false;
                GetComponent<Animator>().SetBool("attaque", true);
                Invoke("ArretAttaque", 0.5f);
            }

            // vitesse du dash
            if (peutAttaquer == false && Mathf.Abs(vitesseX) <= vitesseMax)
            {
                vitesseX *= 2;
            }


            //Applique les vitesses en X et Y
            GetComponent<Rigidbody2D>().velocity = new Vector2(vitesseX, vitesseY);


            //**************************Gestion des animaitons de course et de repos********************************
            //Active l'animation de course si la vitesse de déplacement n'est pas 0, sinon le repos sera jouer par Animator
            if (vitesseX > 0.1f || vitesseX < -0.1f)
            {
                GetComponent<Animator>().SetBool("marche", true);
            }
            else
            {
                GetComponent<Animator>().SetBool("marche", false);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D infoCollision)
    {
        //Animation saut suelement si objet en dessous
        if (Physics2D.OverlapCircle(transform.position, 0.25f))
        {
            GetComponent<Animator>().SetBool("saut", false);
        }

        //Collision avec les ennemis
        if (infoCollision.gameObject.tag == "ennemi")
        {
            if (peutAttaquer == false)
            {
                GetComponent<Animator>().SetBool("mort", false);
                //Collision abeille avec le dash
                abeilleDeplacement.GetComponent<Animator>().enabled = false;
                abeille.GetComponent<Animator>().SetBool("mort", true);
                abeille.GetComponent<Collider2D>().enabled = false;
                Destroy(abeille, 1f);
                
            }
            else 
            {
                estMort = true;
                GetComponent<Animator>().SetBool("mort", true);
                GetComponent<AudioSource>().PlayOneShot(sonMort, 1f);
                Invoke("recommencer", 2f);
            } 
        }

        //Collision avec les trophé = victoire
        if (infoCollision.gameObject.name == "trophee")
        {
            SceneManager.LoadScene(3);
        }

    }

    //Recommence le jeu après la mort
    void recommencer()
    {
        SceneManager.LoadScene(2);
    }

    //Delais entre les attaques
    void ArretAttaque()
    {
        peutAttaquer = true;
        GetComponent<Animator>().SetBool("attaque", false);
    }
}
