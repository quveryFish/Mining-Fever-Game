using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private StoneSpawnScript stoneSpawnScript;

    [SerializeField] private Text textAccel;
    [SerializeField] private Text textSpace;
    [SerializeField] private Text textValue;

    [SerializeField] private Text countTextSpace;
    [SerializeField] private Text countTextAccel;
    [SerializeField] private Text countTextValue;

    [SerializeField] private AudioSource upgradeSound;
    [SerializeField] private AudioSource denySound;

    [SerializeField] private GameObject panel;

    private int aceleratorCostCount = 1;
    private int spaceCostCount =1;
    private int valueCostCount = 1;

    private int aceleratorCount = 0;
    private int spaceCount = 0;
    private int valueCount = 0;

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
        if (scoreManager.score >= 3 * spaceCostCount)
        {
            scoreManager.RemoveScore(3 * spaceCostCount);
            stoneSpawnScript.listLimit += 1;

            upgradeSound.Play();

            spaceCount++;
            countTextSpace.text = $"{stoneSpawnScript.listLimit} - x{spaceCount}(+1)";
            spaceCostCount *= 2;
            textSpace.text = $"More rocks - {2 * spaceCostCount} $";
        }
        else
        {
            Debug.Log("Not enough money");
            denySound.Play();
        }
    }

    public void BuyFasterSpawn()
    {
        if (scoreManager.score >= 5 * aceleratorCostCount)
        {
            scoreManager.RemoveScore(5 * aceleratorCostCount);
            stoneSpawnScript.timerTime -= 0.5f;
            if (stoneSpawnScript.timerTime <= 0)
            {
                stoneSpawnScript.timerTime = 0.1f;
            }

            upgradeSound.Play();

            aceleratorCount++;
            countTextAccel.text = $"{stoneSpawnScript.timerTime} sec - x{aceleratorCount}(-0.5)";

            aceleratorCostCount *= 3;
            textAccel.text = $"Faster rocks spawn - {5 * aceleratorCostCount} $";
        }
        else
        {
            Debug.Log("Not enough money");
            denySound.Play();
        }
    }
    public void BuyOreMoreValue()
    {
        if (scoreManager.score >= 20 * valueCostCount)
        {
            scoreManager.RemoveScore(20 * valueCostCount);
            scoreForBreak++;

            upgradeSound.Play();

            valueCount++;
            countTextValue.text = $"{scoreForBreak} - x{valueCount}(+1)";

            valueCostCount *= 4;
            textValue.text = $"More rocks value - {20 * valueCostCount} $";
        }
        else
        {
            Debug.Log("Not enough money");
            denySound.Play();
        }

    }
    public int GetScoreForBreak()
    {
        return scoreForBreak;
    }
}
