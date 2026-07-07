using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UFOFinish : MonoBehaviour
{
public Transform player;
public GameObject beam;


public float moveSpeed = 8f;

private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}

public IEnumerator PlaySequence()
{
    gameObject.SetActive(true);

    Vector3 target =
        player.position + new Vector3(0, 2f, 0);

    while (Vector3.Distance(transform.position, target) > 0.1f)
    {
        transform.position =
            Vector3.MoveTowards(
                transform.position,
                target,
                moveSpeed * Time.deltaTime);

        yield return null;
    }

    beam.SetActive(true);

    if(audioSource != null)
    {
        audioSource.Play();
    }

    float timer = 0;

    Vector3 startScale = player.localScale;

    while (timer < 1f)
    {
        timer += Time.deltaTime;

        player.localScale =
            Vector3.Lerp(
                startScale,
                Vector3.zero,
                timer);

        yield return null;
    }

   // AFTER — just delete those three lines, ending the coroutine like this:
player.localScale = Vector3.zero;
// coroutine ends here, control returns to FinishLevel() in the game manager
}


}
