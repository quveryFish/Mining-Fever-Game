using UnityEngine;
using UnityEngine.UIElements;

public class QuitGameScript : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    public void QuitGamePanelActive()
    {
        panel.SetActive(true);
    }
    public void QuitGamePanelDeActive()
    {
        panel.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
