using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Detection collision roue et MegaMan
    private void OnCollisionEnter2D(Collision2D infoCollision)
    {
        if (infoCollision.gameObject.name == "Megaman") 
        {
            GetComponent<Animator>().enabled = true;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            Destroy(gameObject, 1f);
        }
    }
}
