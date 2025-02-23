using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } // Instancia única para el patrón Singleton
    [SerializeField] AudioSource sfxAudio, musicAudio; // Referencias a los componentes de audio para efectos y música
    public AudioClip initialMusic; // Clip de música inicial que se reproducirá al comenzar
    [SerializeField] AudioMixer master; // Referencia al mezclador de audio

    public bool isMute; // Indica si el audio está silenciado o no
    public string musicSavedValue = "musicValue";  // Clave para guardar el volumen de la música en PlayerPrefs
    public string sfxSavedValue = "sfxValue";  // Clave para guardar el volumen de los efectos de sonido en PlayerPrefs


    private void Awake()
    {
        // Implementación del patrón Singleton para asegurar que solo haya una instancia de AudioManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject); // Mantiene este objeto entre cambios de escena
        }
        else
        {
            Destroy(this.gameObject); // Si ya existe una instancia, destruye la nueva para evitar duplicados
        }
    }
    void Start()
    {
        // Obtiene los componentes de AudioSource en los primeros hijos del objeto
        sfxAudio = transform.GetChild(0).GetComponent<AudioSource>();
        musicAudio = transform.GetChild(1).GetComponent<AudioSource>();

        // Reproduce la música inicial y carga las preferencias de audio guardadas
        InitialPlayMusic(initialMusic);
        LoadSoundPreferences();
    }
    // Reproduce un efecto de sonido sin detener los anteriores
    public void PlaySFX(AudioClip clip)
    {
        sfxAudio.PlayOneShot(clip);
    }

    // Reproduce una nueva música deteniendo la anterior
    public void PlayMusic(AudioClip clip)
    {
        musicAudio.Stop(); // Detiene la música actual
        musicAudio.clip = clip; // Asigna el nuevo clip de audio
        musicAudio.Play(); // Reproduce la música
        musicAudio.loop = true; // Hace que la música se repita en bucle
    }

    // Método privado para reproducir la música inicial
    void InitialPlayMusic(AudioClip clip)
    {
        musicAudio.clip = clip;
        musicAudio.Play();
        musicAudio.loop = true;
    }

    // Controla el volumen de la música
    public void MusicVolumeControl(float volume)
    {
        // nombre del grupo de audio en el mezclador
        master.SetFloat("Music", volume);
    }

    // Controla el volumen de los efectos de sonido
    public void SFXVolumeControl(float volume)
    {
        master.SetFloat("Sfx", volume);
    }

    // Activa o desactiva el silencio de todo el audio
    public void MuteAll()
    {
        isMute = !isMute; // Alterna entre silencio y sonido
        if (isMute)
        {
            master.SetFloat("Master", -80f); // Silencia todo el audio
        }
        else
        {
            master.SetFloat("Master", 0f); // Restaura el volumen
        }
    }

    // Guarda las preferencias de volumen en PlayerPrefs
    public void SaveSoundPreferences(float levelMusic, float levelSFX)
    {
        PlayerPrefs.SetFloat(musicSavedValue, levelMusic);
        PlayerPrefs.SetFloat(sfxSavedValue, levelSFX);
    }

    // Carga las preferencias de volumen guardadas
    public void LoadSoundPreferences()
    {
        if (PlayerPrefs.HasKey(musicSavedValue)) // Verifica si existen datos guardados
        {
            MusicVolumeControl(PlayerPrefs.GetFloat(musicSavedValue)); // Carga el volumen de la música
            SFXVolumeControl(PlayerPrefs.GetFloat(sfxSavedValue)); // Carga el volumen de los efectos de sonido
        }
    }


}
