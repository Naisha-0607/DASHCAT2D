using UnityEngine;

public class BeamDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("PLAYER HIT!");

            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                Debug.Log("TAKING DAMAGE");
                health.TakeDamage();
            }
            else
            {
                Debug.Log("NO PLAYER HEALTH FOUND");
            }
        }
    }
}