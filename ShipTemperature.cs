using UnityEngine;
using TMPro;

public class ShipTemperature : MonoBehaviour
{
    public float temperature;
    public TextMeshProUGUI textTmp; // Texte pour afficher la température
    public TextMeshProUGUI warningText; // Texte pour l'avertissement de température élevée
    public float highTemperatureThreshold = 100f; // Seuil de température élevée
    public AudioSource warningSound; // AudioSource pour le son d'avertissement
    public AudioClip warningClip; // Clip audio pour le son d'avertissement

    private bool isWarningSoundPlaying = false;

    void Start()
    {
        if (textTmp == null || warningText == null || warningSound == null)
        {
            Debug.LogWarning("Un ou plusieurs composants ne sont pas assignés dans l'éditeur");
        }

        if (warningText != null)
        {
            warningText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        AssignTemperature();

        if (textTmp != null)
        {
            textTmp.text = "Température: " + temperature.ToString("F2") + "°C";
        }

        if (temperature > highTemperatureThreshold)
        {
            if (warningText != null)
            {
                warningText.gameObject.SetActive(true);
                warningText.text = "Attention! Température élevée!";
            }

            if (!isWarningSoundPlaying)
            {
                warningSound.clip = warningClip;
                warningSound.loop = true;
                warningSound.Play();
                isWarningSoundPlaying = true;
            }
        }
        else
        {
            if (warningText != null)
            {
                warningText.gameObject.SetActive(false);
            }

            if (isWarningSoundPlaying)
            {
                warningSound.Stop();
                isWarningSoundPlaying = false;
            }
        }
    }
    void AssignTemperature()
    {
        GameObject closestStar = FindClosestStar();

        if (closestStar != null)
        {
            Star starScript = closestStar.GetComponent<Star>();

            if (starScript != null)
            {
                float distanceToStar = Vector3.Distance(transform.position, closestStar.transform.position);
                float maxDistance = 5000f; // Assurez-vous de définir cette valeur en fonction de la distance maximale que vous avez définie pour la génération des planètes.

                temperature = Mathf.Lerp(starScript.temperature, -273.15f, distanceToStar / maxDistance);
            }
        }
    }

    GameObject FindClosestStar()
    {
        GameObject[] stars = GameObject.FindGameObjectsWithTag("Star");
        GameObject closestStar = null;
        float closestDistanceSqr = Mathf.Infinity;

        foreach (GameObject star in stars)
        {
            Vector3 directionToStar = star.transform.position - transform.position;
            float dSqrToStar = directionToStar.sqrMagnitude;

            if (dSqrToStar < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToStar;
                closestStar = star;
            }
        }

        return closestStar;
    }

    public float GetTemperature()
    {
        return temperature;
    }
}
