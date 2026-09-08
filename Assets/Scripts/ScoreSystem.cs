using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        UpdateText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateText();
    }

    private void UpdateText()
    {
        scoreText.text = score.ToString();
    }
}
