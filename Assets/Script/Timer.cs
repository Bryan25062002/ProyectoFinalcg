using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text UItexto;
    private int contador = 0;

    private void Awake()
    {
        InvokeRepeating("Cronometro", 0f, 1f);
    }

    // Update is called once per frame
    void Cronometro()
    {
        contador++;
        UItexto.text = contador.ToString();
    }
}
