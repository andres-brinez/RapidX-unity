using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsManager : MonoBehaviour
{

    // ** Gestiona los límites del área de juego y realiza acciones cuando los objetos salen de los límites

    // Start is called before the first frame update
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {}

    private void OnTriggerEnter(Collider other) {
    }

    private void OnTriggerExit(Collider other) {
        // Si el objeto que sale de la pantalla es un proyectil, se destruye
        if (other.gameObject.name.Contains("proyectil")){
            Destroy(other.gameObject);
        }
        //  
        else if (other.gameObject.name == "Car"){
            // Si el objeto que sale de la pantalla es el carro, se reinicia la posición del carro
            other.gameObject.transform.position = new Vector3(125.3632f, -3.41f, 74.09748f);
            other.gameObject.transform.rotation = Quaternion.Euler(0, -12-407f, 0);
            Debug.Log("Carro fuera de los límites");

        }
    }
}
