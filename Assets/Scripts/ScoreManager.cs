using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private Text uitext;

    public int score = 0;
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
