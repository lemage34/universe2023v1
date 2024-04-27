using UnityEngine;
using TMPro;

public class MousePointerPlanetResources : MonoBehaviour
{
    public TextMeshProUGUI planetResourcesText; // Référence à votre objet TextMeshProUGUI pour afficher les ressources de la planète
    Camera cam;

    private void Start()
    {
        cam = Camera.main; // Assurez-vous que votre caméra est marquée comme Main Camera
    }

    private void Update()
    {
        DisplayPlanetResourcesUnderMouse();
    }

    void DisplayPlanetResourcesUnderMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            
            // Vérifier si l'objet touché est une planète
            if (hitObject.CompareTag("Planet"))
            {
                // Obtenez le composant qui stocke les informations sur les ressources de la planète
                PlanetResources planetResources = hitObject.GetComponent<PlanetResources>();
                
                if (planetResources != null)
                {
                    string resourcesInfo = planetResources.GetResourcesInfo(); // Obtenez les informations sur les ressources
                    planetResourcesText.text = "Resources on planet:\n" + resourcesInfo; // Met à jour le texte UI
                }
                else
                {
                    planetResourcesText.text = "No resources information available for this planet."; // Si aucune information sur les ressources n'est disponible
                }
            }
            else
            {
                planetResourcesText.text = "Object under mouse pointer is not a planet."; // Si l'objet touché n'est pas une planète
            }
        }
        else
        {
            planetResourcesText.text = "No object under mouse pointer."; // Met à jour le texte UI si aucun objet n'est détecté
        }
    }
}
