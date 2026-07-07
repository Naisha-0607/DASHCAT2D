using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLight : MonoBehaviour
{
    public Transform player;

   public float speed = 1.5f;
public float acceleration = 0.05f;

    void Update()
    {
        // move forward
        transform.position +=
            Vector3.right *
            speed *
            Time.deltaTime;

        // follow cat height
        Vector3 pos = transform.position;
        pos.y = player.position.y;
        transform.position = pos;
        speed += acceleration * Time.deltaTime;

        // caught player
        if(transform.position.x >= player.position.x)
        {
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex
            );
        }
    }
}