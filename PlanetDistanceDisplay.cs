using UnityEngine;

public class PlanetDistanceDisplay : MonoBehaviour
{
    public Transform star; // L'étoile la plus proche sera assignée automatiquement
    public float distanceToStar; // Ceci affichera la distance dans l'inspecteur

    void Start()
    {
        FindClosestStar();
    }

    void Update()
    {
        if (star != null)
        {
            distanceToStar = Vector3.Distance(transform.position, star.position);
        }
    }

    void FindClosestStar()
    {
        float closestDistanceSqr = Mathf.Infinity;
        Transform closestStar = null;
        Star[] stars = GameObject.FindObjectsOfType<Star>(); // Supposant que vos étoiles ont un script ou un tag "Star"

        foreach (Star s in stars)
        {
            Vector3 directionToStar = s.transform.position - transform.position;
            float dSqrToStar = directionToStar.sqrMagnitude;

            if (dSqrToStar < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToStar;
                closestStar = s.transform;
            }
        }

        star = closestStar;
    }
}
