using UnityEngine;

public class OreBreakScript : MonoBehaviour
{
    [SerializeField] private ShopScript ShopScript;
    public int scoreForBreak = 1;

    private void Start()
    {
        ShopScript = FindObjectOfType<ShopScript>();
        scoreForBreak = ShopScript.GetScoreForBreak();
    }

    private void Update()
    {
        if (scoreForBreak == 1)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.gray;
        }
        else if (scoreForBreak == 2)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        else if (scoreForBreak == 3)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (scoreForBreak == 4)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (scoreForBreak >= 5)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }

}
