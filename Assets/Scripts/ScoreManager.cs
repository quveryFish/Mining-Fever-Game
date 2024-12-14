using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    [SerializeField] private Text uitext;

    public float score = 0;
    public void AddScore(float scoreAmount)
    {
        score += scoreAmount;
        uitext.text = $"Score: {score.ToString()} ";
    }

    public void RemoveScore(float scoreAmount)
    {
            score -= scoreAmount;
            uitext.text = $"Score: {score.ToString()} ";
    }



}
