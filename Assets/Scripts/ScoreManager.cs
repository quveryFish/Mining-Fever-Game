using System.Threading;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float timer = 2f;


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
    }

    public void RemoveScore(int scoreAmount)
    {
        score -= scoreAmount;
    }



}
