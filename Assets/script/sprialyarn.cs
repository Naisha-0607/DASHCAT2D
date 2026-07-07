using UnityEngine;
using System.Collections;

public class YarnSpiral : MonoBehaviour
{
    public Transform topPoint;
    public Transform bottomPoint;

    public float travelTime = 1.5f;

    private bool busy;

    public bool IsBusy()
    {
        return busy;
    }

    public void EnterYarn(GameObject cat, bool goingUp)
    {
        if (busy) return;

        StartCoroutine(MoveCat(cat, goingUp));
    }

    IEnumerator MoveCat(GameObject cat, bool goingUp)
    {
        busy = true;

        Stickman stickman = cat.GetComponent<Stickman>();
        Rigidbody2D rb = cat.GetComponent<Rigidbody2D>();

        if (stickman != null)
            stickman.inYarn = true;

        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.gravityScale = 0;
        }

        Vector3 start =
            goingUp ? bottomPoint.position : topPoint.position;

        Vector3 end =
            goingUp ? topPoint.position : bottomPoint.position;

        // instantly snap to start point
        cat.transform.position = start;

        float timer = 0f;

        while (timer < travelTime)
        {
            timer += Time.deltaTime;

            float t = timer / travelTime;

            Vector3 pos = Vector3.Lerp(start, end, t);

            pos.x += Mathf.Sin(t * 10f * Mathf.PI) * 0.3f;

            cat.transform.position = pos;

            yield return null;
        }

        cat.transform.position = end;

        if (rb != null)
        {
            rb.gravityScale = 0.5f;
        }

        if (stickman != null)
            stickman.inYarn = false;

        // wait a tiny bit before allowing re-entry
        yield return new WaitForSeconds(0.25f);

        busy = false;
    }
}