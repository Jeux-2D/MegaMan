using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionBalles : MonoBehaviour
{
    //Collisons balle --> tag ennemis
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        if (infoCollision.gameObject.tag == "ennemi")
        {
            Destroy(infoCollision.gameObject, 0.5f);
            infoCollision.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            infoCollision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2();
            infoCollision.gameObject.GetComponent<Collider2D>().enabled = false;
            infoCollision.gameObject.GetComponent<Animator>().SetBool("mort", true);
            Destroy(gameObject);
        }

    }
}
