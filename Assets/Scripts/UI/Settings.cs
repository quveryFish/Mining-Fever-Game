using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void ActivateShop()
    {
        panel.SetActive(true);
    }
    public void DeActivateShop()
    {
        panel.SetActive(false);
    }
}
