using UnityEngine;

public class SlidingPlatform : MonoBehaviour
{
    public float moveDistance = 3f;
    public float speed = 2f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position = startPos +
            Vector3.right *
            Mathf.Sin(Time.time * speed) *
            moveDistance;
    }
}