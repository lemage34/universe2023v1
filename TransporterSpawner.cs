using UnityEngine;

public class TransporterSpawner : MonoBehaviour
{
    public GameObject transporterPrefab; // Préfab du transporteur
    public int numberOfTransporters = 5; // Nombre de transporteurs à créer
    public float universeSize = 1000f; // Taille de l'univers où les transporteurs peuvent être créés

    void Start()
    {
        SpawnTransporters();
    }

    void SpawnTransporters()
    {
        for (int i = 0; i < numberOfTransporters; i++)
        {
            // Générer une position aléatoire
            float x = Random.Range(-universeSize / 2, universeSize / 2);
            float y = Random.Range(-universeSize / 2, universeSize / 2);
            float z = Random.Range(-universeSize / 2, universeSize / 2);
            Vector3 randomPosition = new Vector3(x, y, z);

            // Créer (spawn) le transporteur à la position générée
            Instantiate(transporterPrefab, randomPosition, Quaternion.identity);
        }
    }
}
