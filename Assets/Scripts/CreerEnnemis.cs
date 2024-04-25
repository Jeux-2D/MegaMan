using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;


public class CreerEnnemis : MonoBehaviour
{

    public GameObject ennemiACreer;         //La roue dentelée à dupliquer
    public GameObject personnage;           //Pour la position de Megaman
    //Déterminer la zone de reproduction
    public float limiteGauche;
    public float limiteDroite;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DupliquerRoue", 0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DupliquerRoue()
    {
        if (personnage.transform.position.x > limiteGauche && personnage.transform.position.x < limiteDroite)
        {
            GameObject copie = Instantiate(ennemiACreer);
            copie.SetActive(true);
            copie.transform.position = new Vector3(Random.Range(personnage.transform.position.x - 8f, personnage.transform.position.x + 8f), 8f, 0);
        }
    }
}
