using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetSceneLoad : MonoBehaviour
{
    public static float planetTemperature; // Variable statique pour stocker la température de la planète

    void OnTriggerEnter(Collider other)
    {
        // Récupérer le script PlanetTemperature attaché à l'objet de collision
        PlanetTemperature planetTempScript = other.GetComponent<PlanetTemperature>();
        if (planetTempScript != null)
        {
            Debug.Log("Bou");
            Debug.Log(planetTemperature);
            PlayerPrefs.SetFloat("PlanetTemperature", planetTempScript.temperature);
            Debug.Log("Température enregistrée : " + planetTempScript.temperature);
            SceneManager.LoadScene("scene02");
        }
        else
        {
            Debug.Log("L'objet entré n'a pas de composant PlanetTemperature");
        }
    }
}
