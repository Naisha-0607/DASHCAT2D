using UnityEngine;

public class TreeLogTeleport : MonoBehaviour
{
    [SerializeField] private Transform destination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position =
                destination.position + Vector3.up * 0.25f;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            if(rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
    }
}