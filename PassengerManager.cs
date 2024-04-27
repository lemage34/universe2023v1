using UnityEngine;

public class PassengerManager : MonoBehaviour
{
    public GameObject passengerPrefab;
    public float pickupDistance = 5f;

    void Update()
    {
        GameObject[] transporters = GameObject.FindGameObjectsWithTag("Transporter");
        
        foreach (GameObject transporterObj in transporters)
        {
            TransporterController transporter = transporterObj.GetComponent<TransporterController>();
            
            if (!transporter.hasPassenger && transporter.currentPassenger == null)
            {
                GeneratePassenger(transporter);
            }
        }
    }

    void GeneratePassenger(TransporterController transporter)
    {
        // Generate passenger
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
        GameObject spawnPlanet = planets[Random.Range(0, planets.Length)];
        GameObject passenger = Instantiate(passengerPrefab, spawnPlanet.transform.position, Quaternion.identity);
        
        transporter.currentPassenger = passenger.transform;
        passenger.transform.SetParent(spawnPlanet.transform, true); // Attach to planet

        // Choose a destination planet different from the spawn planet
        GameObject destinationPlanet;
        do
        {
            destinationPlanet = planets[Random.Range(0, planets.Length)];
        } while (destinationPlanet == spawnPlanet);

        transporter.currentDestination = destinationPlanet.transform;
    }
}
