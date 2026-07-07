using TMPro;
using UnityEngine;

public class TunaManager : MonoBehaviour
{
    public static TunaManager Instance;

    public TMP_Text tunaText;

    public int requiredTuna = 5;

    public int collectedTuna = 0;

    void Awake()
    {
        Instance = this;
        UpdateUI();
    }

    public void CollectTuna()
    {
        collectedTuna++;
        UpdateUI();
    }

void UpdateUI()
{
    tunaText.text =
        collectedTuna +
        "/" +
        requiredTuna;
}

    public bool HasEnoughTuna()
    {
        return collectedTuna >= requiredTuna;
    }

    public int GetCollectedTuna()
    {
        return collectedTuna;
    }
}