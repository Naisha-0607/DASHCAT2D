using UnityEngine;
using System.Collections;

public class TunaCollectible : MonoBehaviour
{
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    private Collider2D col;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        TunaManager.Instance.CollectTuna();

        StartCoroutine(CollectRoutine());
    }

    IEnumerator CollectRoutine()
    {
        // Prevent collecting twice
        col.enabled = false;

        // Hide tuna sprite
        spriteRenderer.enabled = false;

        // Play sound
        if (audioSource != null)
            audioSource.Play();

        // Wait until sound finishes
        yield return new WaitForSeconds(audioSource.clip.length);

        // Remove tuna
        gameObject.SetActive(false);
    }
}