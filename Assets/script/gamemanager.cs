using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyUFO enemyUFO;
    [SerializeField] private Transform finishLine;
    [SerializeField] private CameraFollow cameraFollow;
    private Stickman stickman;
    [SerializeField] private float speedOnWin;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject particleEffect;
    
    private bool resetting;

    private Vector3 initPos;
    private bool won;

    private void Start ()
    {
        stickman = player.GetComponent<Stickman>();
        initPos = player.transform.position;
        won = false;
        resetting = false;
        PlayerPrefs.SetInt(
    "CurrentLevel",
    SceneManager.GetActiveScene().buildIndex);
    }

    private void Update ()
    {
        if(stickman.getSticked() == false)
        {
            // Lowered the reset bound to -50 so the player has plenty of space to swing backward 
            // Change this value depending on where your actual level start boundary is!
            if(player.transform.position.x < -50f)
            {
                ResetGame();
            }
            
            // Keeps the kill floor if they fall down into a pit
            if(player.transform.position.y < -5.2f)
            {
                ResetGame ();
            }
        }

     if (finishLine.position.x < player.transform.position.x && !won)
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

    private void ResetGame ()
    {
        if(!resetting)
        {
            StartCoroutine(ResetRoutine());
        }
    }

 private void Win()
{
    // Stop timer
    LevelTimer.Instance.StopTimer();

    // Calculate score
   float timeLeft = Mathf.Round(LevelTimer.Instance.GetRemainingTime());

// Get remaining lives
int livesLeft = PlayerHealth.Instance.GetCurrentLives();

// Score calculation
int score =
    Mathf.RoundToInt(timeLeft * 10) +
    (livesLeft * 500);
    // Save data for Level Complete screen
    PlayerPrefs.SetFloat("TimeLeft", timeLeft);
    PlayerPrefs.SetInt("CurrentScore", score);
    PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex);

    // UFO flies away
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
IEnumerator FinishLevel()
{
    yield return new WaitForSeconds(4f);

    SceneManager.LoadScene("LevelComplete");
}
    private IEnumerator ResetRoutine()
    {
        resetting = true;
        yield return new WaitForSeconds(1f);
        stickman.reset(initPos);
        resetting = false;
    }
}