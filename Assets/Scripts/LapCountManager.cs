using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCountManager : MonoBehaviour
{

    // ** Detecta cuando el carro cruza la línea


    public int lapCount = 0; // Contador de vueltas, que en si indica la vuelta en la que se encuentra el carro

    // Start is called before the first frame update
    void Start()
    {    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Cuando el carro cruza la línea, se incrementa el contador de vueltas
    private void OnTriggerEnter(Collider other) {
        lapCount++;

        // Se disminuye el contador de vueltas porque cuando el carro cruza la línea por primera vez,  se incrementa el contador de vueltas. Este decremento corrige el conteo inicial.
        Debug.Log("Lap Count: " + lapCount);
        
    
    }

}
