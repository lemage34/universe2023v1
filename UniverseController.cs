using UnityEngine;

public class UniverseController : MonoBehaviour
{
    public GameObject[] starPrefabs;
    public GameObject[] planetPrefabs;
    public int universeSize = 1000;
    public int numberOfStars = 100;
    public int maxPlanetsPerStar = 3;
    public float minPlanetStarDistance = 50;
    public float maxPlanetStarDistance = 200;
    public float minPlanetSize = 0.5f;
    public float maxPlanetSize = 2f;
    public float planetPlaneHeight = 0; // Les planètes seront alignées à cette hauteur y

    void Start()
    {
        GenerateUniverse();
    }

    void GenerateUniverse()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            Vector3 starPosition = new Vector3(Random.Range(-universeSize, universeSize), 
                                              Random.Range(-universeSize, universeSize), 
                                              Random.Range(-universeSize, universeSize));
            GameObject star = Instantiate(starPrefabs[Random.Range(0, starPrefabs.Length)], starPosition, Quaternion.identity);

            int planetCount = Random.Range(1, maxPlanetsPerStar + 1);
            float planetSpacing = (maxPlanetStarDistance - minPlanetStarDistance) / (planetCount + 1); // Calcul de l'espacement

            for (int j = 1; j <= planetCount; j++) // Commencer à 1 pour le premier multiple
            {
                GameObject planetPrefab = planetPrefabs[Random.Range(0, planetPrefabs.Length)];
                GameObject planet = Instantiate(planetPrefab);
                
                float distance = minPlanetStarDistance + planetSpacing * j; // Multiplier l'espacement
                Vector3 randomDirection = Random.onUnitSphere;
                randomDirection.y = planetPlaneHeight; // Assurer que la planète est à la hauteur spécifiée
                Vector3 planetPosition = star.transform.position + (randomDirection.normalized * distance);
                planet.transform.position = planetPosition;

                float scaleSize = Random.Range(minPlanetSize, maxPlanetSize);
                planet.transform.localScale = new Vector3(scaleSize, scaleSize, scaleSize);
                
                planet.AddComponent<PlanetController>(); // Le script PlanetController trouvera l’étoile la plus proche automatiquement
            }
        }
    }
}
