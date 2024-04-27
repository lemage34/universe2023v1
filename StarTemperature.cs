using UnityEngine;

public class StarTemperature : MonoBehaviour
{
    [System.Serializable]
    public class StarTemperatureMapping
    {
        public GameObject starPrefab;
        public int temperature;
    }

    public StarTemperatureMapping[] starTemperatureMappings;

    void Start()
    {
        // Exemple d'utilisation : Accessing the temperature of the first star in the array
        if(starTemperatureMappings.Length > 0)
        {
            int temp = starTemperatureMappings[0].temperature;
            Debug.Log("Temperature of the first star: " + temp);
        }
    }
}
