using UnityEngine;
using System.Collections;

public class EnemyUFO : MonoBehaviour

{
    private bool flyingAway = false;
    private AudioSource audioSource;
    private AudioSource laserAudio;
    [Header("Target")]
    public Transform player;

    [Header("Follow")]
    public float followDistance = 3f;
    public float followHeight = 2f;
    public float moveSpeed = 4f;

    [Header("Hover")]
    public float hoverAmount = 0.3f;
    public float hoverSpeed = 2f;

    [Header("Attack")]
    public GameObject targetBeam;
    public GameObject laserBeam;
    public Transform beamOrigin;

    public float attackInterval = 3f;

    private bool attacking = false;

    private float lockedX;

    void Start()
    {
        targetBeam.SetActive(false);
        laserBeam.SetActive(false);

        StartCoroutine(AttackLoop());
        laserAudio = laserBeam.GetComponent<AudioSource>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (flyingAway)
{
    transform.position +=
        new Vector3(-4f, 5f, 0f) * Time.deltaTime;

    return;
}
        if (player == null)
            return;

        if (!attacking)
        {
            float targetX = player.position.x - followDistance;

            float targetY =
                player.position.y +
                followHeight +
                Mathf.Sin(Time.time * hoverSpeed) * hoverAmount;

            Vector3 targetPos =
                new Vector3(targetX, targetY, transform.position.z);

            transform.position =
                Vector3.Lerp(
                    transform.position,
                    targetPos,
                    moveSpeed * Time.deltaTime);
        }

        // Keep beams under UFO normally
        targetBeam.transform.position =
            new Vector3(
                lockedX,
                beamOrigin.position.y,
                targetBeam.transform.position.z);

        laserBeam.transform.position =
            targetBeam.transform.position;
    }

    IEnumerator AttackLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackInterval);

            attacking = true;

            // Lock the cat's position with a tiny random offset
            lockedX =
                player.position.x +
                Random.Range(-0.5f, 0.5f);

            targetBeam.SetActive(true);
            if (laserAudio != null)
{
    laserAudio.Play();
}

            yield return new WaitForSeconds(0.35f);

            targetBeam.SetActive(false);
            if(audioSource != null)
{
    audioSource.Play();
}

laserBeam.SetActive(true);

            laserBeam.SetActive(true);

            yield return new WaitForSeconds(0.15f);

            laserBeam.SetActive(false);

            attacking = false;
        }
    }
    public void FlyAway()
{
    attacking = false;

    StopAllCoroutines();

    targetBeam.SetActive(false);
    laserBeam.SetActive(false);

    flyingAway = true;
}
}