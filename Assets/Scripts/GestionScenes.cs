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
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            int sceneActive = SceneManager.GetActiveScene().buildIndex +1;
            Debug.Log("L'index de la scene est: " + sceneActive);

            SceneManager.LoadScene(sceneActive);
            Debug.Log("L'index de la scene est: " + sceneActive);
        }
    }
}
