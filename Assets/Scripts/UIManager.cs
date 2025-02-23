using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    // TODO  Hacer lo del score
    // TODO  Hacer lo del tiempo
    public TextMeshProUGUI LapText;

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

    public void UpdateLapText(int lap)
    {
        LapText.text = "Vuelta actual : " + lap;
    }




}
