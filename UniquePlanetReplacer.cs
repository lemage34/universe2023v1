using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UniquePlanetReplacer : MonoBehaviour
{
    public GameObject[] uniquePlanetPrefabs; // Les préfabs des planètes uniques
    public List<string> uniquePlanetNames; // Les noms des planètes uniques

    private bool[] prefabUsed; // Suivi des préfabs qui ont été utilisés

    public int numberOfReplacements = 1; // Nombre de fois que les planètes doivent être remplacées

    private void Start()
    {
        if (uniquePlanetNames.Count != uniquePlanetPrefabs.Length)
        {
            Debug.LogError("Le nombre de noms de planètes ne correspond pas au nombre de préfabs de planètes.");
            return;
        }

        prefabUsed = new bool[uniquePlanetPrefabs.Length];
        StartCoroutine(ReplacePlanetCoroutine());
    }

    private IEnumerator ReplacePlanetCoroutine()
    {
        for(int i = 0; i < numberOfReplacements; i++)
        {
            yield return new WaitForSeconds(15f); // Attendez 30 secondes avant de remplacer une planète

            GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet"); 

            if (planets.Length == 0)
            {
                Debug.LogError("Aucune planète trouvée dans la scène.");
                yield break;
            }

            int randomIndex = Random.Range(0, planets.Length);
            GameObject oldPlanet = planets[randomIndex];

            int prefabIndex;
            do
            {
                prefabIndex = Random.Range(0, uniquePlanetPrefabs.Length);
            } while (prefabUsed[prefabIndex]);

            prefabUsed[prefabIndex] = true; 

            GameObject newPlanet = Instantiate(uniquePlanetPrefabs[prefabIndex], oldPlanet.transform.position, Quaternion.identity);            
        newPlanet.transform.localScale = new Vector3(10.1f, 10.1f, 10.1f); // Réinitialisez l'échelle de la planète
            newPlanet.tag = "Planet"; 
            newPlanet.name = uniquePlanetNames[prefabIndex]; // Attribuer le nom spécifié dans l'inspecteur

            Destroy(oldPlanet);
        }
    }
}
