using UnityEngine;

public class PlanetTemperature : MonoBehaviour
{
    public float temperature;

    void Start()
    {
        AssignTemperature();
    }

    void AssignTemperature()
    {
        GameObject closestStar = FindClosestStar();

        if (closestStar != null)
        {
            Star starScript = closestStar.GetComponent<Star>();

            if (starScript != null)
            {
                float distanceToStar = Vector3.Distance(transform.position, closestStar.transform.position);
                float maxDistance = 5000f; // Assurez-vous de définir cette valeur en fonction de la distance maximale que vous avez définie pour la génération des planètes.

                temperature = Mathf.Lerp(starScript.temperature, -273.15f, distanceToStar / maxDistance);
            }
        }
    }

    GameObject FindClosestStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        GameObject closestStar = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject star in stars)
        {
            Vector3 directionToStar = star.transform.position - transform.position;
            float dSqrToStar = directionToStar.sqrMagnitude;

            if (dSqrToStar < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToStar;
                closestStar = star;
            }
        }

        return closestStar;
    }

    public float GetTemperature()
    {
        return temperature;
    }
}
