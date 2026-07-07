using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float startTime = 300f;
    public static LevelTimer Instance;

    public TMP_Text timerText;

   // 5 minutes

    private float timeRemaining;

    private bool timerRunning = true;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timeRemaining = startTime;
    }

    void Update()
    {
        if (!timerRunning)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            timerRunning = false;

           PlayerPrefs.SetString("LoseReason", "Time's Up!");
SceneManager.LoadScene("YouLost");
        }

        UpdateTimerUI();
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    public float GetRemainingTime()
    {
        return timeRemaining;
    }
}