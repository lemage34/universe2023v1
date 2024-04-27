using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawnPrefabs; // Les prefabs que vous voulez instancier.
    public float spawnDelay = 5f; // Le délai avant que l'objet ne soit instancié.
    public float spawnDistance = 5f; // Distance de la planète où l'objet sera instancié.
    public int maxObjects = 10; // Le nombre maximum d'objets à instancier.

    private GameObject[] planets;
    private float timeSinceLastSpawn = 0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        
        if (timeSinceLastSpawn >= spawnDelay)
        {
            planets = GameObject.FindGameObjectsWithTag("Planet");

            // Obtenir tous les objets instanciés dans la scène ayant le tag "ShipSpawn".
            GameObject[] spawnedShips = GameObject.FindGameObjectsWithTag("ShipSpawn");
            
            if (planets.Length > 0 && objectsToSpawnPrefabs.Length > 0 && spawnedShips.Length < maxObjects)
            {
                // Sélectionner une planète aléatoire
                GameObject randomPlanet = planets[Random.Range(0, planets.Length)];

                // Sélectionner un prefab aléatoire
                GameObject randomPrefab = objectsToSpawnPrefabs[Random.Range(0, objectsToSpawnPrefabs.Length)];

                // Calculer une position aléatoire autour de la planète
                Vector3 randomDirection = Random.onUnitSphere;
                Vector3 spawnPosition = randomPlanet.transform.position + randomDirection.normalized * spawnDistance;
                
                // Instancier le prefab sélectionné à la position calculée
                Instantiate(randomPrefab, spawnPosition, Quaternion.identity);

                timeSinceLastSpawn = 0f;
            }
            else
            {
                if (planets.Length == 0) Debug.LogWarning("No planets found. Make sure your planets have the 'Planet' tag.");
                if (objectsToSpawnPrefabs.Length == 0) Debug.LogWarning("No objects to spawn. Make sure you have assigned the prefabs.");
                if (spawnedShips.Length >= maxObjects) Debug.LogWarning("Max ship objects reached. Can't spawn more ships.");
            }
        }
    }
}
