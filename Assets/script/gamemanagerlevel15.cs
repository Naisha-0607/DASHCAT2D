using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanagerlevel15 : MonoBehaviour
{
  [SerializeField] private EnemyUFO enemyUFO;
[SerializeField] private Transform finishLine;
[SerializeField] private CameraFollow cameraFollow;
[SerializeField] private float speedOnWin;


[SerializeField] private GameObject player;
[SerializeField] private GameObject particleEffect;

private Stickman stickman;

private bool resetting;
private bool won;

private Vector3 initPos;

private void Start()
{
    stickman = player.GetComponent<Stickman>();

    initPos = player.transform.position;

    won = false;
    resetting = false;
    PlayerPrefs.SetInt(
    "CurrentLevel",
    SceneManager.GetActiveScene().buildIndex);
}

private void Update()
{
    if (!stickman.getSticked())
    {
        if (player.transform.position.x < -50f)
        {
            ResetGame();
        }

        if (player.transform.position.y < -5.2f)
        {
            ResetGame();
        }
    }

 

// AFTER
if(finishLine.position.x < player.transform.position.x && !won)
{
    if (TunaManager.Instance.HasEnoughTuna())
    {
        won = true;
        Win();
    }
    else
    {
        PlayerPrefs.SetString("LoseReason", "Not Enough Tuna!");
        SceneManager.LoadScene("YouLost");
    }
}
}

private void ResetGame()
{
    if (!resetting)
    {
        StartCoroutine(ResetRoutine());
    }
}

private IEnumerator ResetRoutine()
{
    resetting = true;

    yield return new WaitForSeconds(1f);

    player.transform.position = initPos;

    resetting = false;
}

private void Win()
{
    LevelTimer.Instance.StopTimer();

    float timeLeft = Mathf.Round(LevelTimer.Instance.GetRemainingTime());

    int livesLeft = PlayerHealth.Instance.GetCurrentLives();

    int score =
        Mathf.RoundToInt(timeLeft * 10) +
        (livesLeft * 500);

    PlayerPrefs.SetFloat("TimeLeft", timeLeft);
    PlayerPrefs.SetInt("CurrentScore", score);
    PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);
    PlayerPrefs.Save();

    if (enemyUFO != null)
        enemyUFO.FlyAway();

    stickman.Win(speedOnWin);

    particleEffect.SetActive(true);
    particleEffect.transform.parent = null;

    cameraFollow.Win();
int highestUnlocked = PlayerPrefs.GetInt("HighestUnlocked", 2);
int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
if (nextLevel > highestUnlocked)
{
    PlayerPrefs.SetInt("HighestUnlocked", nextLevel);
}
PlayerPrefs.Save();
    StartCoroutine(FinishLevel());
}

private IEnumerator FinishLevel()
{
    yield return new WaitForSeconds(3f);

    SceneManager.LoadScene("endingscene");
}


}
