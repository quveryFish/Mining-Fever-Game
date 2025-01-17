using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MainMenuScoreText : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    private const string SCORE = "Score";

    private void Awake()
    {
        GetScoreText();
    }
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
        GetScoreText();
    }
    private void GetScoreText()
    {
        int setScote = PlayerPrefs.GetInt(SCORE, 0);
        scoreText.text = $"--Score-- \n {setScote}";
    }
}
