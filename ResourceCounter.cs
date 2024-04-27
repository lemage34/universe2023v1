using UnityEngine;
using System.Collections.Generic;

public class ResourceCounter : MonoBehaviour
{
    void Start()
    {
        CountResources();
    }

    void CountResources()
    {
        PlanetResources[] planets = FindObjectsOfType<PlanetResources>();

        Dictionary<string, int> resourceCounts = new Dictionary<string, int>();

        foreach (PlanetResources planet in planets)
        {
            foreach (var resource in planet.assignedResources) // Utilisez assignedResources ici
            {
                if (resourceCounts.ContainsKey(resource.resourceName))
                {
                    resourceCounts[resource.resourceName] += resource.quantity; // Utilisez quantity ici
                }
                else
                {
                    resourceCounts[resource.resourceName] = resource.quantity; // Utilisez quantity ici
                }
            }
        }

        foreach (var resource in resourceCounts)
        {
            Debug.Log("Total " + resource.Key + ": " + resource.Value);
        }
    }
}
