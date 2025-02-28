using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public bool isGameStarted;
    public bool isGameOver;
    public int score;
    public int lapCount;

    public float speed = 55.0f; // Velocidad del carro hacia adelante
    public float turnSpeed = 55.0f; // Velocidad de giro


    // Este metodo se ejecuta antes de Start, singleton
    private void Awake()
    {
        // Si no hay una instancia de GameManager
        if (Instance == null)
        {
            // Se asigna la instancia actual
            Instance = this;
            // No se destruye el objeto al cargar una nueva escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Si ya hay una instancia de GameManager, se destruye el objeto actual
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isGameStarted = false;
        isGameOver = false;
        score = 0;
        lapCount = 0;
    }

    public void ChangeScene(string nameScene){

        SceneManager.LoadScene(nameScene);

    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    public void UpdateScore(int points)
    {
        score += points;
    }

    public void UpdateLapCount()
    {
        lapCount++;
        IncreaseSpeed(10.0f);
        IncreaseTurnSpeed(10.0f);
    }

    // aumenta la velocidad del carro
    public void IncreaseSpeed(float increment)
    {
        speed += increment;
    }

    // aumenta la velocidad de giro del carro
    public void IncreaseTurnSpeed(float increment)
    {
        turnSpeed += increment;
    }
}
