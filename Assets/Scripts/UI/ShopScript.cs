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
    public int valueCount = 0;

    private int scoreForBreak =1;

    //More ores
    private const string LIST_LIMIT = "ListLimit";
    private const string SPACE_COUNT = "SpaceCount";
    private const string SPACE_COST_COUNT = "SpaceCostCount";

    //Acceleration
    private const string TIMER_TIME = "TimerTime";
    private const string ACCEL_COUNT = "AceleratorCount";
    private const string ACCEL_COST_COUNT = "AceleratorCostCount";
    //MoreValue
    private const string SCORE_FOR_BREAK = "ScoreForBreak";
    private const string VALUE_COUNT = "ValueCount";
    private const string VALUE_COST_COUNT = "valueCostCount";
    private const string COST_FOR_BREAK = "costForBreak";

    private void Awake()
    {
        SetSavesAll();

        GetScoreForBreak();
        RefreshAllText();
    }



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
            textSpace.text = $"Upgrade max ores limit - {3 * spaceCostCount} $";

            SaveSpace();
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
            textAccel.text = $"Upgrade spawning speed - {5 * aceleratorCostCount} $";

            SaveAccel();
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
            //Debug.Log($"ScoreForBreak {scoreForBreak}");
            upgradeSound.Play();

            valueCount++;
            countTextValue.text = $"{scoreForBreak} - x{valueCount}(+1)";

            valueCostCount *= 4;
            textValue.text = $"Upgrade ore value - {20 * valueCostCount} $";

            SaveValue();
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


    private void RefreshAllText()
    {
        //More ores
        countTextSpace.text = $"{stoneSpawnScript.listLimit} - x{spaceCount}(+1)";
        textSpace.text = $"Upgrade max ores limit - {3 * spaceCostCount} $";

        //Acceleration
        countTextAccel.text = $"{stoneSpawnScript.timerTime} sec - x{aceleratorCount}(-0.5)";
        textAccel.text = $"Upgrade spawning speed - {5 * aceleratorCostCount} $";

        //MoreValue
        countTextValue.text = $"{scoreForBreak} - x{valueCount}(+1)";
        textValue.text = $"Upgrade ore value - {20 * valueCostCount} $";

    }

    private void SetSavesAll()
    {
        //More ores
        stoneSpawnScript.listLimit = PlayerPrefs.GetInt(LIST_LIMIT, 2);
        spaceCount = PlayerPrefs.GetInt(SPACE_COUNT, 0);
        spaceCostCount = PlayerPrefs.GetInt(SPACE_COST_COUNT, 1);

        //Acceleration
        stoneSpawnScript.timerTime = PlayerPrefs.GetFloat(TIMER_TIME, 3f);
        aceleratorCount = PlayerPrefs.GetInt(ACCEL_COUNT, 0);
        aceleratorCostCount = PlayerPrefs.GetInt(ACCEL_COST_COUNT, 1);
        //MoreValue
        scoreForBreak = PlayerPrefs.GetInt(SCORE_FOR_BREAK, 1);
        valueCount = PlayerPrefs.GetInt(VALUE_COUNT, 0);
        valueCostCount = PlayerPrefs.GetInt(VALUE_COST_COUNT, 1);
        scoreForBreak = PlayerPrefs.GetInt(COST_FOR_BREAK, 1);
    }

    private void SaveAccel()
    {
        PlayerPrefs.SetFloat(TIMER_TIME, stoneSpawnScript.timerTime);
        PlayerPrefs.SetInt(ACCEL_COUNT, aceleratorCount);
        PlayerPrefs.SetInt(ACCEL_COST_COUNT, aceleratorCostCount);

        PlayerPrefs.Save();
    }
    private void SaveSpace()
    {
        PlayerPrefs.SetInt(LIST_LIMIT, stoneSpawnScript.listLimit);
        PlayerPrefs.SetInt(SPACE_COUNT, spaceCount);
        PlayerPrefs.SetInt(SPACE_COST_COUNT, spaceCostCount);

        PlayerPrefs.Save();
    }
    private void SaveValue()
    {
        PlayerPrefs.SetInt(SCORE_FOR_BREAK, scoreForBreak);
        PlayerPrefs.SetInt(VALUE_COUNT, valueCount);
        PlayerPrefs.SetInt(VALUE_COST_COUNT, valueCostCount);
        PlayerPrefs.SetInt(COST_FOR_BREAK, scoreForBreak);

        PlayerPrefs.Save();
    }
}

