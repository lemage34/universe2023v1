using UnityEngine;

public class SpaceshipMover : MonoBehaviour
{
    public float speed = 5f; // Vitesse du vaisseau spatial.

    private GameObject[] planets;
    private Transform targetPlanet;

    void Start()
    {
        ChooseRandomPlanetAsTarget();
    }

    void Update()
    {
        if (targetPlanet != null)
        {
            MoveTowardsTarget();
        }
        else
        {
            ChooseRandomPlanetAsTarget();
        }
    }

    void ChooseRandomPlanetAsTarget()
    {
        planets = GameObject.FindGameObjectsWithTag("Planet");

        if (planets.Length > 0)
        {
            GameObject randomPlanet = planets[Random.Range(0, planets.Length)];
            targetPlanet = randomPlanet.transform;
        }
        else
        {
            Debug.LogWarning("No planets found. Make sure your planets are tagged with 'Planet'.");
        }
    }

    void MoveTowardsTarget()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPlanet.position, step);

        // Orienter le vaisseau spatial vers la planète cible.
        Vector3 direction = targetPlanet.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
