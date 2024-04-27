using UnityEngine;
using UnityEngine.UI;

public class StarDistanceDisplay2 : MonoBehaviour
{
    public Text distanceText; // Assurez-vous de lier cet élément dans l'éditeur Unity.

    private void Update()
    {
        GameObject nearestStar = FindNearestStar();

        if (nearestStar != null)
        {
            float distance = Vector3.Distance(transform.position, nearestStar.transform.position);
            UpdateDistanceText(distance);
        }
    }

    GameObject FindNearestStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        GameObject nearestStar = null;
        float minDistance = float.MaxValue;

        foreach (GameObject star in stars)
        {
            float distance = Vector3.Distance(transform.position, star.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestStar = star;
            }
        }

        return nearestStar;
    }

    void UpdateDistanceText(float distance)
    {
        if (distanceText != null)
        {
            distanceText.text = "Distance to nearest star: " + distance.ToString("F2") + " units";
        }
        else
        {
            Debug.LogWarning("Distance Text not assigned in the inspector.");
        }
    }
}
