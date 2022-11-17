using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;


public class LogicaNPC1 : MonoBehaviour
{

    public GameObject simboloMision;
    public LogicaPersonaje jugador;
    public GameObject panelNPC;
    
    public GameObject panelNPCMision;
    public TextMeshProUGUI textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public GameObject[] objetivos;
    public int numDeObjetivos;
    public GameObject botonDeMision;


    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = objetivos.Length;
        textoMision.text = "Recoge los 3 sacos de oro que estan al rededor del mapa" + "\n Restantes: " + numDeObjetivos;

        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && aceptarMision == false && jugador.puedoSaltar == true)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);


            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = true;
            if (aceptarMision == false)
            {
                panelNPC.SetActive(true);
                
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;
            if (aceptarMision == false)
            {
                panelNPC.SetActive(false);
                
                
            }


        }
    }



    public void No()
    {
        jugador.enabled = true;

        
        panelNPC.SetActive(true);
    }

    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;
        for (int i = 0; i < objetivos.Length; i++)
        {
            objetivos[i].SetActive(true);
        }


        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        
        panelNPCMision.SetActive(true);
    }
}
