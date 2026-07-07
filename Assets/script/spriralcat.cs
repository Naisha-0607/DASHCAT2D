using UnityEngine;

public class YarnTrigger : MonoBehaviour
{
public YarnSpiral yarn;
public bool goingUp;

private AudioSource audioSource;

private void Start()
{
    audioSource = GetComponent<AudioSource>();
}

private void OnTriggerEnter2D(Collider2D other)
{
    if (!other.CompareTag("Player"))
        return;

    if (yarn.IsBusy())
        return;

    audioSource.Play();

    Debug.Log(goingUp ? "GOING UP" : "GOING DOWN");

    yarn.EnterYarn(other.gameObject, goingUp);
}


}
