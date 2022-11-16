using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LogicaObjetivosSacosOro : MonoBehaviour
{
    public int numDeObjetivos;
    public Text textoMision;
    public GameObject botonDeMision;


    public LogicaPersonaje logicaPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Recoge los 3 sacos de oro que estan al rededor del mapa" + "\n Restantes: " + numDeObjetivos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "objetivo")
        {
            Destroy(col.transform.parent.gameObject);
            numDeObjetivos--;
            textoMision.text = "Recoge los 3 sacos de oro que estan al rededor del mapa" + "\n Restantes: " + numDeObjetivos;

            if(numDeObjetivos <= 0)
            {
                logicaPersonaje.itemPersonaje++;
                textoMision.text = "Completaste la misión";
                botonDeMision.SetActive(true);
            }
        }
    }
}
