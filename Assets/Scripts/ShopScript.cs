using UnityEngine;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private StoneSpawnScript stoneSpawnScript;
    [SerializeField] private GameObject panel;


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
        scoreManager.RemoveScore(2);
        stoneSpawnScript.listLimit += 1;
    }

}
