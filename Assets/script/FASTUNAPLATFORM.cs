using UnityEngine;

public class OneWaySlide : MonoBehaviour
{
[SerializeField] private float slideSpeed = 8f;


private AudioSource audioSource;
private bool soundPlaying;

private void Start()
{
    audioSource = GetComponent<AudioSource>();

    if(audioSource == null)
    {
        Debug.LogWarning("No AudioSource found on " + gameObject.name);
    }
}

private void OnCollisionStay2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        Rigidbody2D rb =
            collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = new Vector2(
                slideSpeed,
                rb.linearVelocity.y
            );
        }

        if (audioSource != null && !soundPlaying)
        {
            audioSource.Play();
            soundPlaying = true;
        }
    }
}

private void OnCollisionExit2D(Collision2D collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        if(audioSource != null)
        {
            audioSource.Stop();
        }

        soundPlaying = false;
    }
}


}
