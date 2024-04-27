using UnityEngine;

public class TemperatureRangeCounter : MonoBehaviour
{
    public int lowerBound;
    public int upperBound;

    private void Update()
    {
        int planetCountWithinRange = 0;
        int totalPlanetCount = 0;
        int totalStarCount = 0;

        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");

        foreach (GameObject planet in planets)
        {
            PlanetTemperature planetTemperatureScript = planet.GetComponent<PlanetTemperature>();
            
            if (planetTemperatureScript != null)
            {
                int temp = (int)planetTemperatureScript.GetTemperature();
                
                if (temp >= lowerBound && temp <= upperBound)
                {
                    planetCountWithinRange++;
                }
            }

            totalPlanetCount++;
        }

        totalStarCount = stars.Length;

        //Debug.Log($"Planets within temperature range: {planetCountWithinRange}" +
        //          $"\nTotal planets: {totalPlanetCount}" +
        //          $"\nTotal stars: {totalStarCount}");
    }
}
