using UnityEngine;

// Ce script doit être attaché à chaque étoile
public class StarClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        PlayerMover.instance.MoveToStar(transform.position);
    }
}
