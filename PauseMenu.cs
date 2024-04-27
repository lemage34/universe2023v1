using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject[] uiElementsToToggle; // Un tableau pour stocker tous les éléments UI que vous voulez contrôler
    private bool isPaused = false;

    private void Start()
    {
        // Assurez-vous que les éléments UI sont désactivés au démarrage
        ToggleUIElements(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        ToggleUIElements(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        ToggleUIElements(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // Fonction pour activer ou désactiver les éléments UI spécifiés
    void ToggleUIElements(bool setActive)
    {
        foreach(GameObject element in uiElementsToToggle)
        {
            element.SetActive(setActive);
        }
    }

    public void LoadMenu()
    {
        // Ici, vous pouvez charger votre menu principal ou une autre scène.
        // SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
