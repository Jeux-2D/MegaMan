using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int sceneActive = SceneManager.GetActiveScene().buildIndex;
        //Scene intro a scene de jeu
        if (Input.GetKeyDown(KeyCode.Space) && sceneActive == 0) 
        {
            SceneManager.LoadScene(1);
        }

        //Scene mort a jeu
        if (Input.GetKeyDown(KeyCode.Space) && sceneActive == 2)
        {
            SceneManager.LoadScene(1);
        }

        //Scene gagne a intro
        if (Input.GetKeyDown(KeyCode.Space) && sceneActive == 3)
        {
            SceneManager.LoadScene(0);
        }
    }
}
