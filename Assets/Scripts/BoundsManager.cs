using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundsManager : MonoBehaviour
{
    // ** Gestiona los límites del área de juego y realiza acciones cuando los objetos salen de los límites

    public GameObject damageScreen;
    float screenTime;
    bool hasDamaged = false;
    public float tiempoDeEspera = 5f;


    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        if (hasDamaged && screenTime < tiempoDeEspera)
        {
            screenTime += Time.deltaTime; // Cuenta el tiempo
        }
        // si ya pasaron 2.5 segundos se desactiva la pantalla de daño y se reinicia la posicion 
        else if (screenTime >= tiempoDeEspera)
        {
            desactivateDamageScreen();
            resetPosition();

        }
    }


    private void OnTriggerExit(Collider other)
    {
        // Si el objeto que sale de la pantalla es un proyectil, se destruye
        if (other.gameObject.name.Contains("proyectil"))
        {
            Destroy(other.gameObject);
        }
        //  
        else if (other.gameObject.name == "Car")
        {
            Debug.Log("Carro sale de la pantalla");
            // cuando se sale se activa una imagen color rojo para indicar que está en peligro
            damageScreen.SetActive(true);
            hasDamaged = true;

        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Car" && hasDamaged)
        {
            Debug.Log("Carro volvió a los limites");
            desactivateDamageScreen();

        }
    }

    void resetPosition()
    {
        GameObject gameObject = GameObject.FindWithTag("Car");

        // Si el objeto que sale de la pantalla es el carro, se reinicia la posición del carro
        gameObject.transform.position = new Vector3(125.3632f, -3.41f, 74.09748f);
        gameObject.transform.rotation = Quaternion.Euler(0, -12 - 407f, 0);
        Debug.Log("Carro reset position ");

    }

    void desactivateDamageScreen()
    {
        damageScreen.SetActive(false);
        hasDamaged = false;
        screenTime = 0;
    }
}

