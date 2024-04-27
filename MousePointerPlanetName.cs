using UnityEngine;
using TMPro;

public class MousePointerPlanetName : MonoBehaviour
{
    public TextMeshProUGUI planetNameText; // Référence à votre objet TextMeshProUGUI pour afficher le nom de la planète
    Camera cam;

    private void Start()
    {
        cam = Camera.main; // Assurez-vous que votre caméra est marquée comme Main Camera
    }

    private void Update()
    {
        DisplayPlanetNameUnderMouse();
    }

    void DisplayPlanetNameUnderMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            
            // Vérifier si l'objet touché est une planète
            if (hitObject.CompareTag("Planet"))
            {
                string planetName = hitObject.name;
                planetNameText.text = "Planet under mouse pointer: " + planetName; // Met à jour le texte UI
            }
            else
            {
                planetNameText.text = "Object under mouse pointer is not a planet."; // Si l'objet touché n'est pas une planète
            }
        }
        else
        {
            planetNameText.text = "No object under mouse pointer."; // Met à jour le texte UI si aucun objet n'est détecté
        }
    }
}
