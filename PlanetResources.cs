using UnityEngine;

[System.Serializable]
public class Resource
{
    public string resourceName;
    public float probability; // Probabilité d'avoir cette ressource (0-100)
    public float weight; // Poids à l'unité
    public float price; // Prix à l'unité
}

[System.Serializable]
public class PlanetResource
{
    public string resourceName;
    public int quantity;
    public float totalWeight;
    public float totalPrice;
    public float weight; // poids unitaire de la ressource
    public float price; // prix unitaire de la ressource


}

public class PlanetResources : MonoBehaviour
{
    public Resource[] resourceProbabilities; // Définissez ceci dans l'inspecteur Unity
    public PlanetResource[] assignedResources; // Ceci affichera les ressources assignées dans l'inspecteur

    void Start()
    {
        AssignResources();
    }

    void AssignResources()
    {
        foreach (Resource resource in resourceProbabilities)
        {
            float roll = UnityEngine.Random.Range(0f, 100f);
            if (roll <= resource.probability)
            {
                int quantity = UnityEngine.Random.Range(1, 100); // Changez ceci pour modifier la quantité assignée
                PlanetResource planetResource = new PlanetResource
                {
                    resourceName = resource.resourceName,
                    quantity = quantity,
                    totalWeight = resource.weight * quantity,
                    totalPrice = resource.price * quantity
                };

                AddResource(planetResource);
            }
        }
    }

    void AddResource(PlanetResource resource)
    {
        int index = System.Array.FindIndex(assignedResources, r => r.resourceName == resource.resourceName);
        if (index < 0) // La ressource n'est pas encore assignée
        {
            PlanetResource[] newResources = new PlanetResource[assignedResources.Length + 1];
            assignedResources.CopyTo(newResources, 0);
            newResources[newResources.Length - 1] = resource;
            assignedResources = newResources;
        }
        else // La ressource est déjà assignée, alors ajoutons simplement la quantité, le poids et le prix
        {
            assignedResources[index].quantity += resource.quantity;
            assignedResources[index].totalWeight += resource.totalWeight;
            assignedResources[index].totalPrice += resource.totalPrice;
        }
    }

    // Cette méthode retournera une chaîne contenant les informations de toutes les ressources assignées à la planète
    public string GetResourcesInfo()
    {
        string resourcesInfo = "";
        foreach (PlanetResource resource in assignedResources)
        {
            resourcesInfo += resource.resourceName + ": " +
                            resource.quantity + " units, " +
                            "Weight: " + resource.totalWeight + " kg, " +
                            "Price: $" + resource.totalPrice + "\n";
        }

        return resourcesInfo == "" ? "No resources available." : resourcesInfo;
    }
}
