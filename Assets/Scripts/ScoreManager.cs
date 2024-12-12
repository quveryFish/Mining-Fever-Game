using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float timer = 2f;

    [SerializeField] private Text uitext;

    [SerializeField] private int score = 0;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Debug.Log(score);
            timer = 2f;
        }

    }


    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        uitext.text = $"Score: {score.ToString()} ";
    }

    public void RemoveScore(int scoreAmount)
    {
        score -= scoreAmount;
        uitext.text = $"Score: {score.ToString()} ";
    }



}
