using UnityEngine;
using TMPro; // Assurez-vous d'inclure cet espace de noms pour TextMeshPro

public class MousePointerTemperature : MonoBehaviour
{
    public TextMeshProUGUI temperatureText; // Référence à votre objet TextMeshProUGUI
    Camera cam;

    private void Start()
    {
        cam = Camera.main; // Assurez-vous que votre caméra est marquée comme Main Camera
    }

    private void Update()
    {
        CheckTemperatureOfObjectUnderMouse();
    }

    void CheckTemperatureOfObjectUnderMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            PlanetTemperature planetTemperature = hit.transform.GetComponent<PlanetTemperature>();
            
            if (planetTemperature != null)
            {
                float temperature = planetTemperature.GetTemperature();
                temperatureText.text = "Temperature of object: " + temperature.ToString("F2") + "°C"; // Met à jour le texte UI
            }
            else
            {
                temperatureText.text = "Object under mouse pointer does not have a temperature."; // Si l'objet n'a pas de composant PlanetTemperature
            }
        }
        else
        {
            temperatureText.text = "No object under mouse pointer."; // Met à jour le texte UI si aucun objet n'est détecté
        }
    }
}
