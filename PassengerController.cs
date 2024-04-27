using UnityEngine;

public class PassengerController : MonoBehaviour
{
    public GameObject passengerPrefab;
    public GameObject spaceship;
    public Transform currentPassenger;
    public Transform currentDestination;
    public int successfulCourses = 0;

    void Update()
    {
        if (currentPassenger == null)
        {
            // Generate passenger
            GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
            GameObject spawnPlanet = planets[Random.Range(0, planets.Length)];
            GameObject passengerInstance = Instantiate(passengerPrefab, spawnPlanet.transform.position, Quaternion.identity);
            passengerInstance.transform.SetParent(spawnPlanet.transform, true); // Set planet as the parent
            currentPassenger = passengerInstance.transform;

            // Choose a destination planet different from the spawn planet
            GameObject destinationPlanet;
            do
            {
                destinationPlanet = planets[Random.Range(0, planets.Length)];
            } while (destinationPlanet == spawnPlanet);
            currentDestination = destinationPlanet.transform;
        }
        else
        {
            // Check if the spaceship is near the passenger and has no passenger yet
            if ((spaceship.transform.position - currentPassenger.position).magnitude < 50 && spaceship.GetComponent<SpaceshipController>().hasPassenger == false)
            {
                spaceship.GetComponent<SpaceshipController>().PickUpPassenger(currentPassenger);
                currentPassenger.SetParent(spaceship.transform, true); // Set spaceship as the parent when picked up
            }

            // Check if the spaceship is near the destination and has a passenger
            if ((spaceship.transform.position - currentDestination.position).magnitude < 50 && spaceship.GetComponent<SpaceshipController>().hasPassenger == true)
            {
                spaceship.GetComponent<SpaceshipController>().DropOffPassenger();
                Destroy(currentPassenger.gameObject);
                currentPassenger = null;
                successfulCourses++;
            }
        }
    }
}
