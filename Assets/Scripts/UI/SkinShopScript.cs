using UnityEngine;
using UnityEngine.UI;

public class SkinShopScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private AudioSource denySound;
    [SerializeField] private AudioSource upgradeSound;

    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject player;

    [System.Serializable]
    public class Skin
    {
        public string name;
        public Color color;
        public int cost;
        public Text buttonText;
        public bool isPurchased;
    }

    [SerializeField] private Skin[] skins;

    private void Start()
    {
        ResetSkinUI();
    }

    public void ResetSkin()
    {
        player.GetComponent<SpriteRenderer>().color = Color.white;
        ResetSkinUI();
        upgradeSound.Play();
    }

    public void BuySkin(int skinIndex)
    {
        if (skinIndex < 0 || skinIndex >= skins.Length)
        {
            Debug.LogError("Index Error!");
            return;//
        }

        Skin selectedSkin = skins[skinIndex];

        if (!selectedSkin.isPurchased && scoreManager.score >= selectedSkin.cost)
        {
            scoreManager.RemoveScore(selectedSkin.cost);
            player.GetComponent<SpriteRenderer>().color = selectedSkin.color;

            selectedSkin.isPurchased = true;
            selectedSkin.cost = 0;
            selectedSkin.buttonText.text = "Equiped";

            ResetOtherButtons(skinIndex);

            upgradeSound.Play();
        }
        else if (selectedSkin.isPurchased)
        {
            player.GetComponent<SpriteRenderer>().color = selectedSkin.color;

            ResetOtherButtons(skinIndex);
            selectedSkin.buttonText.text = "Equiped";
            upgradeSound.Play();
        }
        else
        {
            Debug.Log("Not enough!");
            denySound.Play();
        }
    }

    public void ActivateShop()
    {
        panel.SetActive(true);
    }

    public void DeActivateShop()
    {
        panel.SetActive(false);
    }

    private void ResetSkinUI()
    {
        foreach (Skin skin in skins)
        {
            if (skin.isPurchased)
            {
                skin.buttonText.text = "Equip";
            }
            else
            {
                skin.buttonText.text = $"Buy ({skin.cost})";
            }
        }
    }

    private void ResetOtherButtons(int activeSkinIndex)
    {
        for (int i = 0; i < skins.Length; i++)
        {
            if (i != activeSkinIndex && skins[i].buttonText.text == "Equiped")
            {
                skins[i].buttonText.text = "Equip";
            }
        }
    }
}
