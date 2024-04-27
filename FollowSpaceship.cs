using UnityEngine;

public class FollowSpaceship : MonoBehaviour
{
    public Transform spaceship; // Référence au transform du vaisseau spatial
    public Vector3 offset; // Décalage de la position de la caméra par rapport au vaisseau spatial

    private void LateUpdate()
    {
        if (spaceship != null)
        {
            // Mettre à jour la position de la caméra pour qu’elle suive le vaisseau spatial avec un décalage
            transform.position = spaceship.position + offset;
            
            // Orienter la caméra dans la direction du vaisseau spatial
            transform.forward = spaceship.forward;
        }
    }
}
