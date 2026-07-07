using UnityEngine;

public class HeartPowerUp : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        if (PlayerHealth.Instance.GetCurrentLives() < PlayerHealth.Instance.maxLives)
        {
            PlayerHealth.Instance.AddLife();

            if (collectSound != null)
                AudioSource.PlayClipAtPoint(
                    collectSound.clip,
                    transform.position);

            Destroy(gameObject);
        }
    }
}