using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public float orbitSpeed = 1f;
    private Transform closestStar;

    private void Start()
    {
        FindClosestStar();
    }

    private void Update()
    {
        if (closestStar != null)
        {
            OrbitAroundStar();
        }
    }

    void FindClosestStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star"); // Assurez-vous que vos étoiles ont le tag "Star"

        float minDistance = float.MaxValue;

        foreach (GameObject star in stars)
        {
            float distance = Vector3.Distance(transform.position, star.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestStar = star.transform;
            }
        }
    }

    void OrbitAroundStar()
    {
        Vector3 axisOfRotation = Vector3.up; // Faire tourner les planètes autour de l'axe vertical
        transform.RotateAround(closestStar.position, axisOfRotation, orbitSpeed * Time.deltaTime);
    }
}
