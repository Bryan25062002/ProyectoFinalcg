using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JefeMovimiento : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator ani;
    public Quaternion angulo;
    public float grado;

    public GameObject target;




    public void ComportamientoEnemigo()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5)
        {
            ani.SetBool ("run", false);
            cronometro += 1 * Time.deltaTime;
            if (cronometro >= 4)
            {
                rutina = Random.Range (0, 2);
                cronometro = 0;
            }
            switch(rutina)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;

                case 1:
                    grado = Random.Range (0, 360);
                    angulo = Quaternion.Euler (0, grado, 0);
                    rutina++;
                    break;

                case 2:
                    transform.rotation = Quaternion.RotateTowards (transform.rotation, angulo, 0.5f);
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            transform.rotation = Quaternion.RotateTowards (transform.rotation, rotation, 2);
            ani.SetBool ("walk", false);

            ani.SetBool ("run", true);
            transform.Translate (Vector3.forward * 2 * Time.deltaTime);
        }
    
    }
    
    ////////// Lansallamas //////////
    public bool lanzaLlamas;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject cabeza;
    private float cronometro2;

    ///////// Jump Attack //////////
    public float jumpDistanci;
    public bool directionSkill;


    public int fase = 1;
    public float HPMin;
    public float HPMax;
    public Image barra;
    public AudioSource musica;
    public bool muerto;


    
    
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent <Animator>();
        target = GameObject.Find("Maria WProp J J Ong");
    }

    // Update is called once per frame
    void Update()
    {
        ComportamientoEnemigo();
    }
}
