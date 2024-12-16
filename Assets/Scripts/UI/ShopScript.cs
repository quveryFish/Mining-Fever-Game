using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private StoneSpawnScript stoneSpawnScript;

    [SerializeField] private Text textAccel;
    [SerializeField] private Text textSpace;
    [SerializeField] private Text textValue;
    [SerializeField] private GameObject panel;

    private int aceleratorCount = 1;
    private int spaceCount =1;
    private int valueCount = 1;

    private int scoreForBreak =1;

    public void ActivateShop()
    {
        panel.SetActive(true);
    }
    public void DeActivateShop()
    {
        panel.SetActive(false);
    }

    public void BuyMoreSpaceOne()
    {
        if (scoreManager.score >= 2 * spaceCount)
        {
            scoreManager.RemoveScore(2 * spaceCount);
            stoneSpawnScript.listLimit += 1;
            spaceCount++;
            textSpace.text = $"More rocks - {2 * spaceCount} points";
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    public void BuyFasterSpawn()
    {
        if (scoreManager.score >= 5 * aceleratorCount)
        {
            scoreManager.RemoveScore(5 * aceleratorCount);
            stoneSpawnScript.timerTime -= 0.5f;
            aceleratorCount++;
            textAccel.text = $"Faster rocks spawn - {5 * aceleratorCount} points";
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
    public void BuyOreMoreValue()
    {
        if (scoreManager.score >= 20 * valueCount)
        {
            scoreManager.RemoveScore(20 * valueCount);
            scoreForBreak++;
            valueCount += 3;
            textValue.text = $"More rocks value - {20 * valueCount} points";
        }
    }
    public int GetScoreForBreak()
    {
        return scoreForBreak;
    }
}
