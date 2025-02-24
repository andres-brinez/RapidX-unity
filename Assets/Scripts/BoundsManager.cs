using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoundsManager : MonoBehaviour
{
    // ** Gestiona los límites del área de juego y realiza acciones cuando los objetos salen de los límites


    float timeWait = UIManager.Instance.tiempoDeEspera;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {
        float screenTimeDamaged = UIManager.Instance.screenTime;
        bool hasDamaged = UIManager.Instance.hasDamaged;

        if (hasDamaged && screenTimeDamaged < timeWait)
        {
            UIManager.Instance.screenTime += Time.deltaTime; // Cuenta el tiempo
        }
        // si ya pasaron 2.5 segundos se desactiva la pantalla de daño y se reinicia la posicion 
        else if (screenTimeDamaged >= timeWait)
        {
            UIManager.Instance.desactivateDamageScreen();
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
            UIManager.Instance.activateDamageScreen();
        }
    }

    // Cuando el carro se encuentra dentro de los limites, se desactiva la pantalla de daño
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Car" && UIManager.Instance.hasDamaged)
        {
            Debug.Log("Carro volvió a los limites");
            UIManager.Instance.desactivateDamageScreen();


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


}

