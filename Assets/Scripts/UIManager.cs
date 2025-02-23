using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // TODO  Hacer lo del score
    // TODO  Hacer lo del tiempo de juego
    // Todo hacer que se vea cuanto tiempo tengo para volver a los limites 
    public TextMeshProUGUI LapText;
    
    public GameObject damageScreen;
    public bool hasDamaged = false;
    public float screenTime;
    public float tiempoDeEspera = 5f;

    public static UIManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (hasDamaged && screenTime < tiempoDeEspera)
        {
            screenTime += Time.deltaTime; // Cuenta el tiempo
        }
        // si ya pasaron 2.5 segundos se desactiva la pantalla de daño y se reinicia la posicion 
        else if (screenTime >= tiempoDeEspera)
        {
            desactivateDamageScreen();

        }
    }


    public void UpdateLapText(int lap)
    {
        LapText.text = "Vuelta actual : " + lap;
    }

    public void desactivateDamageScreen()
    {
        damageScreen.SetActive(false);
        hasDamaged = false;
        screenTime = 0;
    }

    public void activateDamageScreen()
    {
        damageScreen.SetActive(true);
        hasDamaged = true;
    }






}
