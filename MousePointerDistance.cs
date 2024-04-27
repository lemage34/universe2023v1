using UnityEngine;
using TMPro; // Assurez-vous d'inclure cet espace de noms pour TextMeshPro

public class MousePointerDistance : MonoBehaviour
{
    public TextMeshProUGUI distanceText; // Référence à votre objet TextMeshProUGUI
    Camera cam;

    private void Start()
    {
        cam = Camera.main; // Assurez-vous que votre caméra est marquée comme Main Camera
    }

    private void Update()
    {
        CheckDistanceToObjectUnderMouse();
    }

    void CheckDistanceToObjectUnderMouse()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            float distance = Vector3.Distance(cam.transform.position, hit.transform.position);
            distanceText.text = "Distance to object: " + distance.ToString("F2") + " units."; // Met à jour le texte UI
        }
        else
        {
            distanceText.text = "No object under mouse pointer."; // Met à jour le texte UI si aucun objet n'est détecté
        }
    }
}
