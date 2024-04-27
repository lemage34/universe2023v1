using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Spaceship : MonoBehaviour
{
    public int maxStorageCapacity;
    public TextMeshProUGUI storageText; 
    public TextMeshProUGUI capacityText; 

    private Dictionary<string, (int quantity, float totalWeight, float totalPrice)> resourceStorage = new Dictionary<string, (int, float, float)>();

    private void Update()
    {
        CheckForNearbyPlanets();
        DisplayCurrentStock();
    }

    private void CheckForNearbyPlanets()
    {
        PlanetResources[] planets = FindObjectsOfType<PlanetResources>();
        foreach (PlanetResources planet in planets)
        {
            float distanceToPlanet = Vector3.Distance(transform.position, planet.transform.position);
            if (distanceToPlanet < 100) 
            {
                LoadResources(planet);
            }
        }
    }

private void LoadResources(PlanetResources planet)
{
    foreach (PlanetResource resource in planet.assignedResources)
    {
        if(resource.quantity <= 0) continue;

        int spaceAvailable = maxStorageCapacity - GetCurrentStorage();
        int amountToLoad = Mathf.Min(spaceAvailable, resource.quantity);

        if (!resourceStorage.ContainsKey(resource.resourceName))
        {
            resourceStorage[resource.resourceName] = (0, 0f, 0f);
        }

        var currentResource = resourceStorage[resource.resourceName];
        currentResource.quantity += amountToLoad;
        // Ajouter le poids et le prix pour la quantité spécifique qui est chargée
        currentResource.totalWeight += resource.weight * amountToLoad;
        currentResource.totalPrice += resource.price * amountToLoad;

        resourceStorage[resource.resourceName] = currentResource;

        // Réduire la quantité, le poids et le prix sur la planète
        resource.quantity -= amountToLoad; 
        // Ne pas réinitialiser le poids et le prix total sur la planète ici
    }

    // Réinitialiser le poids et le prix total de toutes les ressources sur la planète après le chargement
    foreach (PlanetResource res in planet.assignedResources)
    {
        res.totalWeight = 0f;
        res.totalPrice = 0f;
    }
}


    private int GetCurrentStorage()
    {
        int totalQuantity = 0;
        foreach (var resource in resourceStorage.Values)
        {
            totalQuantity += resource.quantity;
        }
        return totalQuantity;
    }

    private void DisplayCurrentStock()
    {
        storageText.text = "";
        float totalWeightInShip = 0;
        foreach (var resource in resourceStorage)
        {
            storageText.text += $"Ressource: {resource.Key}, Quantité: {resource.Value.quantity}, Poids Total: {resource.Value.totalWeight}, Prix Total: {resource.Value.totalPrice}\n";
            totalWeightInShip += resource.Value.totalWeight;
        }

        capacityText.text = $"Poids total dans le vaisseau: {totalWeightInShip} / Capacité de stockage maximale: {maxStorageCapacity}";
    }
}
