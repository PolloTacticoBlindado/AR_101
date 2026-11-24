using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [Header("Paneles")]
    public GameObject mainMenu;
    public GameObject tutorialPanel;
    public GameObject creditsPanel;
    public GameObject gameSettingsButton;

    [Header("Audio")]
    public AudioSource backgroundMusic;

    void Start()
    {
        VolverMenu();

        if (backgroundMusic != null &&
            !backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }

    public void Jugar()
    {
        mainMenu.SetActive(false);
        tutorialPanel.SetActive(true);
        creditsPanel.SetActive(false);
        gameSettingsButton.SetActive(false);
    }

    public void CerrarTutorial()
    {
        tutorialPanel.SetActive(false);
        gameSettingsButton.SetActive(true);
    }

    public void AbrirCreditos()
    {
        mainMenu.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void VolverMenu()
    {
        mainMenu.SetActive(true);
        tutorialPanel.SetActive(false);
        creditsPanel.SetActive(false);
        gameSettingsButton.SetActive(false);
    }

    public void Salir()
    {
        Application.Quit();
    }
}