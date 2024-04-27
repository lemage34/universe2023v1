using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetNamer : MonoBehaviour
{
    public List<string> planetNames = new List<string> { "Athena", "Hera", "Zeus", "Apollo", "Hermes" }; // Liste des noms possibles

    private void Start()
    {
        StartCoroutine(RenamePlanets());
    }

    private IEnumerator RenamePlanets()
    {
        yield return new WaitForSeconds(1f); // Attendre 1 seconde pour s'assurer que toutes les planètes sont instanciées

        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
        
        foreach (GameObject planet in planets)
        {
            if (planetNames.Count > 0) // S'il reste des noms dans la liste
            {
                int randomIndex = Random.Range(0, planetNames.Count); // Choisir un indice aléatoire
                planet.name = planetNames[randomIndex]; // Renommer la planète
                planetNames.RemoveAt(randomIndex); // Retirer le nom utilisé de la liste
            }
            else
            {
                Debug.LogWarning("Not enough names to assign to all planets.");
            }
        }
    }
}
