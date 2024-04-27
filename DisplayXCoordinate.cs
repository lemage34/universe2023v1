using UnityEngine;
using UnityEngine.UI;

public class DisplayXCoordinate : MonoBehaviour
{
    public Text xCoordinateText; // Référence à votre Text UI

    void Start()
    {
        if (xCoordinateText == null)
        {
            Debug.LogError("Text UI not assigned!"); // S'il n'y a pas de référence Text UI
        }
    }

    void Update()
    {
        if (xCoordinateText != null)
        {
            float xCoordinate = transform.position.x; // Obtenir la coordonnée X du vaisseau
            Debug.Log("Vaisseau X Coordinate: " + xCoordinate); // Afficher la coordonnée X dans la console
            xCoordinateText.text = "X Coordinate: " + xCoordinate.ToString("F2"); // Mettre à jour le Text UI
        }
    }
}
