using UnityEngine;

[System.Serializable]
public class PlanetType
{
    public GameObject prefab;
    public float minTemperature;
    public float maxTemperature;
}

public class PlanetTransformer : MonoBehaviour
{
    public PlanetType[] planetTypes;

    private void Start()
    {
        TransformPlanetBasedOnTemperature();
    }

    void TransformPlanetBasedOnTemperature()
    {
        PlanetTemperature planetTemperatureComponent = GetComponent<PlanetTemperature>();
        if (planetTemperatureComponent != null)
        {
            float currentTemperature = planetTemperatureComponent.GetTemperature();

            foreach (PlanetType planetType in planetTypes)
            {
                if (currentTemperature >= planetType.minTemperature && currentTemperature <= planetType.maxTemperature)
                {
                    TransformPlanet(planetType.prefab);
                    return;
                }
            }
        }
    }

void TransformPlanet(GameObject newPlanetPrefab)
{
    if (newPlanetPrefab != null)
    {
        // Instantiez la nouvelle planète sans définir de parent
        GameObject newPlanet = Instantiate(newPlanetPrefab, transform.position, transform.rotation);
        
        // Si vous voulez définir un parent, vous pouvez le faire ici et ensuite réinitialiser l'échelle de la planète
        newPlanet.transform.parent = transform.parent;
        newPlanet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f); // Réinitialisez l'échelle de la planète
        
        Destroy(gameObject); // Détruit la vieille planète
    }
}

}
