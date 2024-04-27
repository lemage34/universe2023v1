using UnityEngine;

public class PlanetOrbit : MonoBehaviour
{
    public float orbitSpeed = 10f; // Vitesse de l'orbite de la planète autour de l'étoile

    private Transform star; // Référence à l'étoile autour de laquelle la planète orbitera

    private void Start()
    {
        // Trouver l'étoile la plus proche
        FindClosestStar();
    }

    private void Update()
    {
        // Faire tourner la planète autour de l'étoile s'il y a une étoile assignée
        if (star != null)
        {
            OrbitAroundStar();
        }
    }

    // Méthode pour trouver l'étoile la plus proche
    private void FindClosestStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        float closestDistance = Mathf.Infinity;

        foreach (GameObject starObj in stars)
        {
            float distance = Vector3.Distance(transform.position, starObj.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                star = starObj.transform;
            }
        }

        // Attacher la planète à l'étoile la plus proche comme enfant
        if (star != null)
        {
            transform.SetParent(star);
        }
    }

    // Méthode pour faire tourner la planète autour de l'étoile
    private void OrbitAroundStar()
    {
        transform.RotateAround(star.position, Vector3.up, orbitSpeed * Time.deltaTime);
    }
}
