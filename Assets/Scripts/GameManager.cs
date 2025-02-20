using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public bool isGameStarted;
    public bool isGameOver;
    public int score;
    public int lapCount;
    
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

    // Update is called once per frame
    void Update()
    {
        
                
    }

    public void updateScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }

}
