using UnityEngine;

public class Target : MonoBehaviour
{
    public GameObject explosionPrefab;
    public AudioClip explosionSound;

    private void OnDestroy()
    {
        // Instancier l'effet d'explosion
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }

        // Créer un objet temporaire pour jouer le son d'explosion
        if (explosionSound != null)
        {
            GameObject temporaryAudioHost = new GameObject("TempAudio");
            temporaryAudioHost.transform.position = transform.position; // Positionne le son à l'endroit de la cible

            AudioSource audioSource = temporaryAudioHost.AddComponent<AudioSource>();
            audioSource.clip = explosionSound;
            audioSource.playOnAwake = false;

            audioSource.Play();

            Destroy(temporaryAudioHost, explosionSound.length); // Détruit l'objet après la lecture du son
        }
    }
}
