
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject mainMenu;
    public GameObject tutorialPanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    [Header("Audio")]
    public AudioSource backgroundMusic;
    public Slider volumeSlider;

    void Start()
    {
        MostrarMenuPrincipal();

        if (backgroundMusic != null && volumeSlider != null)
        {
            volumeSlider.SetValueWithoutNotify(backgroundMusic.volume);
        }
    }

    // Cierra todos los paneles
    public void CerrarPaneles()
    {
        mainMenu.SetActive(false);
        tutorialPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    // Abre el menu principal
    public void MostrarMenuPrincipal()
    {
        CerrarPaneles();
        mainMenu.SetActive(true);
    }

    // Boton de jugar
    public void Jugar()
    {
        CerrarPaneles();
        tutorialPanel.SetActive(true);
    }

    // Cierra el tutorial e inicia la experiencia AR
    public void CerrarTutorial()
    {
        CerrarPaneles();
    }

    // Abre los ajustes
    public void AbrirAjustes()
    {
        CerrarPaneles();
        settingsPanel.SetActive(true);
    }

    // Abre los creditos
    public void AbrirCreditos()
    {
        CerrarPaneles();
        creditsPanel.SetActive(true);
    }

    // Modifica el volumen de la musica
    public void CambiarVolumen(float valor)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = valor;
        }
    }

    // Cierra la aplicacion
    public void Salir()
    {
        Application.Quit();
    }
}
