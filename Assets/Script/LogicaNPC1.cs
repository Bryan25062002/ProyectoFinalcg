using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class LogicaNPC1 : MonoBehaviour
{

    public GameObject simboloMision;
    public LogicaPersonaje jugador;
    public GameObject panelNPC;
    public GameObject panelNPC2;
    public GameObject panelNPCMision;
    public Text textoMision;
    public bool jugadorCerca;
    public bool aceptarMision;
    public int numDeObjetivos;


    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && aceptarMision == false)
        {
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);


            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            jugador.enabled = false;
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            jugadorCerca = false;

            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }

    public void No()
    {
        jugador.enabled = true;

        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);
    }

    public void Si()
    {
        jugador.enabled = true;
        aceptarMision = true;


        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true);
    }
}
