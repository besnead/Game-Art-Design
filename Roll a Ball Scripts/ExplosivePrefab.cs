using UnityEngine;
using System.Collections;

public class ExplosivePrefab : MonoBehaviour
{
    public float delay = 2.0f; // Delay before explosion
    public GameObject explosionPrefab; // Reference to the explosion particle effect prefab
    public AudioClip explosionAudioClip;

    void Start()
    {
        // Invoke the Explode method after the specified delay
        Invoke("Explode", delay);
    }

    void Explode()
    {
        // Instantiate the explosion particle effect at the same position as this object
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionAudioClip, transform.position);

        // Destroy the instantiated object
        Destroy(gameObject);
    }
}
