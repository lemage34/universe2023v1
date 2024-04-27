using UnityEngine;

public class ShipController : MonoBehaviour
{
    public Camera cam; // Référence à la caméra principale

    private void Update()
    {
        // Vérifie si le bouton gauche de la souris est cliqué
        if (Input.GetMouseButtonDown(0))
        {
            // Crée un rayon à partir de la position de la souris
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Vérifie si le rayon touche quelque chose
            if (Physics.Raycast(ray, out hit))
            {
                // Trouve la direction vers la position touchée
                Vector3 directionToLook = hit.point - transform.position;
                directionToLook.y = 0; // Assure que le vaisseau ne change pas d'orientation en hauteur

                // Fait tourner le vaisseau vers la direction calculée
                Quaternion targetRotation = Quaternion.LookRotation(directionToLook);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
            }
        }
    }
}
