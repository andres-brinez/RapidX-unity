using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform carTransform;

    // El offset es un vector que tiene la posicion que se quiere mantener con respecto al carro
    public Vector3 offset; // Se crea un offset para que la cámara no esté exactamente en la misma posición que el carro sino que mantenga una distancia con respecto a él

    public float smoothSpeed = 0.125f; // Velocidad de suavizado para el movimiento de la cámara

    // Start is called before the first frame update
    void Start()
    {

        // Se encuentra el objeto con el tag "Car" y se obtiene su transform
        carTransform = GameObject.FindWithTag("Car").transform;

        // Calcula el offset inicial, este se puede modificar en el editor de Unity
        offset = new Vector3(-0.9f, 7.21f, -18.7f); // ** Se cambia si se cambia la posición de la cámara en el editor de Unity

    }

    // Para que la cámara siga al carro. de esta forma se asegura que la cámara se mueva después de que el carro se haya movido y evita la interrupción de la cámara
    void LateUpdate()
    {
        // La posición deseada de la cámara es igual a la posición del carro más el offset
        Vector3 desiredPosition = carTransform.position + carTransform.TransformDirection(offset);

        // Actualizar la posición de la cámara directamente sin suavizado
        transform.position = desiredPosition;

        // La rotación de la cámara es igual a la rotación del carro
        transform.rotation = carTransform.rotation;
    }
}

