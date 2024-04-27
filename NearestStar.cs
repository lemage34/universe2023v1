using UnityEngine;
using UnityEngine.UI; // Assurez-vous d'ajouter cette ligne si vous utilisez l'UI de Unity

public class NearestStar : MonoBehaviour
{
    
    public Text angleText; // Référence à l'objet Text UI

    void Update()
    {
        
        FindNearestStar();
        FindNearestStarHeading();

        
    }

    void FindNearestStar()
{
    GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
    
    if (stars.Length == 0)
    {
        Debug.Log("No stars found");
        return;
    }
    
    GameObject nearestStar = null;
    float nearestDistance = Mathf.Infinity;
    
    foreach (GameObject star in stars)
    {
        float distance = Vector3.Distance(transform.position, star.transform.position);
        if (distance < nearestDistance)
        {
            nearestDistance = distance;
            nearestStar = star;
        }
    }
    
    if (nearestStar != null)
    {
        Debug.Log("Nearest star distance: " + nearestDistance);
    }
    else
    {
        Debug.Log("No nearest star found");
    }
}

void FindNearestStarHeading()
{
    GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
    
    if (stars.Length == 0)
    {
        Debug.Log("No stars found");
        return;
    }
    
    GameObject nearestStar = null;
    float nearestDistance = Mathf.Infinity;
    
    foreach (GameObject star in stars)
    {
        float distance = Vector3.Distance(transform.position, star.transform.position);
        if (distance < nearestDistance)
        {
            nearestDistance = distance;
            nearestStar = star;
        }
    }
    
    if (nearestStar != null)
    {
        Vector3 toStar = (nearestStar.transform.position - transform.position).normalized;
        Vector3 shipForward = transform.forward;
        
        float dotProduct = Vector3.Dot(toStar, shipForward);
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;
        
        angleText.text = "Heading angle to nearest star: " + angle.ToString("F2"); // Affichage de l'angle dans l'objet Text UI
                Debug.Log("Text Updated: " + angleText.text); // Ajouter un message de débogage

        Debug.Log("Heading angle to nearest star: " + angle);
        
        // The heading will be 0 when the ship is pointing directly at the nearest star.
        // As the ship turns away from the star, the heading value will increase.
    }
    else
    {
        Debug.Log("No nearest star found");
    }
}





}
