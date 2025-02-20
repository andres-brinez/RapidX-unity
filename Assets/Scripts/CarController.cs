using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public float horizontalInput, forwardInput;
    public float speed = 40.0f; // Velocidad del carro hacia adelante
    public float turnSpeed = 50.0f; // Velocidad de giro
    public float fixedYPosition = -3.61f; // Posición fija en el eje Y

    public float powerUpSpeed = 5.0f;
    public float powerUpTurnSpeed = 5.0f;
    public int powerUpDuration = 10;




    public GameObject projectilePrefab;
    public Transform firePoint; // Punto de disparo que es un gameObject vacío dentro del carro 
    public bool hasPowerUp;

    private bool canMoveForward = true; // Variable para controlar si el coche puede moverse hacia adelante



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Si el jugador presiona la barra espaciadora, se dispara un proyectil
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Se instancia un proyectil en la posición del jugador
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }

        moveCar();


        // Mantener la posición fija en el eje Y
        // ** Esto se hace para corregir un problema de cuando se hace una colisión con un obstáculo, el carro se hunde en el suelo y cambiar la posición en el eje Y
        Vector3 position = transform.position;
        position.y = fixedYPosition;
        transform.position = position;

    }

    private void moveCar()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");


        // Aplicar el movimiento hacia adelante y hacia atrás solo si canMoveForward es true
        if (canMoveForward)
        {
            // Aplicar el movimiento hacia adelante y hacia atrás
            // Vector3.forward representa el eje Z positivo
            // Time.deltaTime asegura que el movimiento sea suave y dependiente del tiempo
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        }
        // Aplicar la rotación del coche
        // Vector3.up representa el eje Y
        // La rotación se basa en la entrada horizontal del usuario
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

    }

    private void moveCarPowerUp()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        if (canMoveForward)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * (speed * powerUpSpeed) * forwardInput);
        }
        transform.Rotate(Vector3.up, (turnSpeed * powerUpTurnSpeed) * horizontalInput * Time.deltaTime);
    }

    // Método que se llama cuando el carro colisiona con otro objeto
    private void OnCollisionEnter(Collision collision)
    {

        // Si el objeto con el que colisiona el carro es un proyectil, se destruye el proyectil
        if (collision.gameObject.name.Contains("obstacle"))
        {
            Debug.Log("colisión");
            canMoveForward = false; // Desactiva el movimiento hacia adelante

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Si el objeto con el que deja de colisionar el carro es un obstáculo, se reactiva el movimiento hacia adelante
        if (collision.gameObject.name.Contains("obstacle"))
        {
            Debug.Log("fin de colisión");
            canMoveForward = true; // Reactiva el movimiento hacia adelante
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si el objeto con el que colisiona el carro es un obstáculo, se destruye el obstáculo
        if (other.CompareTag("Powerup"))
        {
            Powerup();
            StartCoroutine(PowerUpTimer());

            Destroy(other.gameObject);
        }
    }

    private void Powerup()
    {
        hasPowerUp = true;
        speed += powerUpSpeed;
        turnSpeed += powerUpTurnSpeed;
    }

    IEnumerator PowerUpTimer()
    {
        yield return new WaitForSeconds(powerUpDuration);
        // Se restaura la velocidad del carro
        speed -= powerUpSpeed;
        turnSpeed -= powerUpTurnSpeed;
        hasPowerUp = false;
    }




    // aumenta la velocidad 


}



