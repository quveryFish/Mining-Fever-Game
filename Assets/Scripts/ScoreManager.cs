using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private Text uitext;

    public int score = 0;

    private const string SCORE = "Score";
    private void Awake()
    {
        score = PlayerPrefs.GetInt(SCORE);

        RefreshText();
    }
    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        uitext.text = $"{score.ToString()} $";
        PlayerPrefs.SetInt(SCORE, score);
        PlayerPrefs.Save();
    }

    public void RemoveScore(int scoreAmount)
    {
            score -= scoreAmount;
            uitext.text = $"{score.ToString()} $";
            PlayerPrefs.SetInt(SCORE, score);
            PlayerPrefs.Save();
    }

    private void RefreshText()
    {
        uitext.text = $"{score.ToString()} $";
    }


}
