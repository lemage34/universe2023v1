using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;
    public Transform projectileSpawnPoint; // Point d'ancrage pour les tirs

    void Update()
    {
        // Détecter un clic droit de la souris
        if (Input.GetMouseButtonDown(1))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && projectileSpawnPoint != null)
        {
            // Création du projectile
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);

            // Appliquer une force initiale au projectile
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Utiliser AddForce pour une application plus naturelle de la force
                rb.AddForce(projectileSpawnPoint.forward * projectileSpeed, ForceMode.VelocityChange);
            }
        }
        else
        {
            Debug.LogError("Projectile prefab ou projectileSpawnPoint n'est pas défini");
        }
    }
}
