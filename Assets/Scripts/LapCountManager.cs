using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapCountManager : MonoBehaviour
{

    // ** Detecta cuando el carro cruza la línea de meta y actualiza el contador de vueltas **

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
        
        GameManager.Instance.lapCount = lapCount ;

        Debug.Log("Lap Count: " + GameManager.Instance.lapCount);
        
    
    }

}
