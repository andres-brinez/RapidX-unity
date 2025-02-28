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
    [SerializeField] private TextMeshProUGUI ScoreText;
        
    public GameObject damageScreen;
    public bool hasDamaged = false;
    public float screenTime;
    public float tiempoDeEspera = 1f;
    private GameObject LapUI;



    // game objets que tiene el text de lap
    private GameObject informationUI;

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

    void Start()
    {
        informationUI = transform.Find("InformationUI").gameObject;
        informationUI.SetActive(false);
        damageScreen.SetActive(false);
    }
    private void Update()
    {
        
    }

    public void UpdateLapText()
    {
        var lap=GameManager.Instance.lapCount;
        LapText.text = "Vuelta actual : " + lap;
    }

    public void UpdateScoreText()
    {
        ScoreText.text = "Puntos: " + GameManager.Instance.score;
    }
    public void desactivateDamageScreen()
    {
        damageScreen.SetActive(false);
        hasDamaged = false;
        screenTime = 0;
        DesactivateInformationUI();
    }

    public void activateDamageScreen()
    {
        damageScreen.SetActive(true);
        hasDamaged = true;
        Debug.Log("Damaged activado");
        ActivateLapInformation();

    }

    public void ShowGameOverInfomation()
    {

        informationUI.SetActive(true);
        TextMeshProUGUI text = informationUI.GetComponentInChildren<TextMeshProUGUI>(); 
        text.text = "Perdiste";       
    }

    public void ActivateLapInformation()
    {
        informationUI.SetActive(true);
        TextMeshProUGUI text = informationUI.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "Estás fuera de los limites";
    }

    public void DesactivateInformationUI()
    {

        informationUI.SetActive(false);
    }





}
