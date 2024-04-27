using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Temps avant que le projectile ne soit automatiquement détruit
    public float lifeTime = 60f;

    private void Start()
    {
        // Détruire le projectile après un certain temps (60 secondes dans ce cas)
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject); // Détruire immédiatement l'objet cible
            Destroy(gameObject); // Détruire le projectile après la collision
        }
    }
}
