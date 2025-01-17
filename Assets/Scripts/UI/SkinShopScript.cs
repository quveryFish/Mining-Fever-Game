using UnityEngine;
using UnityEngine.UI;
using static SkinShopScript;

public class SkinShopScript : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    [SerializeField] private AudioSource denySound;
    [SerializeField] private AudioSource upgradeSound;

    [SerializeField] private GameObject panel;

    [SerializeField] private GameObject player;

    [SerializeField] private Sprite origPlayer;

    [System.Serializable]
    public class Skin
    {
        public string name;
        public Sprite spriteImg;
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
        player.GetComponent<SpriteRenderer>().sprite = origPlayer;
        ResetSkinUI();
        upgradeSound.Play();
    }

    public void BuySkin(int skinIndex)
    {
        if (skinIndex < 0 || skinIndex >= skins.Length)
        {
            Debug.LogError("Index Error!");
            return;
        }

        Skin selectedSkin = skins[skinIndex];
        if (!selectedSkin.isPurchased && scoreManager.score >= selectedSkin.cost)
        {
            scoreManager.RemoveScore(selectedSkin.cost);


            player.GetComponent<SpriteRenderer>().sprite = selectedSkin.spriteImg;

            selectedSkin.isPurchased = true;
                selectedSkin.buttonText.text = "Equip";
                selectedSkin.cost = 0;//

            selectedSkin.buttonText.text = "Equiped";//
            ResetOtherButtons(skinIndex);

            upgradeSound.Play();
        }
        else if (selectedSkin.isPurchased)
        {
            player.GetComponent<SpriteRenderer>().sprite = selectedSkin.spriteImg;

            ResetOtherButtons(skinIndex);
            selectedSkin.buttonText.text = "Equiped";
            upgradeSound.Play();
        }
        else
        {
            Debug.Log("Not enough!");
            selectedSkin.buttonText.text = $"Buy - {selectedSkin.cost} $";
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
                skin.buttonText.text = $"Buy - {skin.cost} $";
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
