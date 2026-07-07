using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    [System.Serializable]
    public class LevelButton
    {
        public Button button;
        public GameObject lockIcon;
    }

    public LevelButton[] levelButtons;

    void Start()
    {
        int highestUnlocked = PlayerPrefs.GetInt("HighestUnlocked", 2);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelBuildIndex = i + 2;
            bool isUnlocked = levelBuildIndex <= highestUnlocked;

            // Enable/disable button interaction
            levelButtons[i].button.interactable = isUnlocked;

            // Show/hide lock icon
            if (levelButtons[i].lockIcon != null)
                levelButtons[i].lockIcon.SetActive(!isUnlocked);

            // Assign click
            int index = levelBuildIndex;
            levelButtons[i].button.onClick.AddListener(
                () => SceneManager.LoadScene(index));
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }
}