using UnityEngine;
using UnityEngine.UIElements;

public class OreBreakScript : MonoBehaviour
{
    private ShopScript shopScript;
    private StoneSpawnScript stoneSpawnScript;
    private Animator Animator;

    public int scoreForBreak = 1;
    private int valueCount;

    [SerializeField] Color finalcolor = Color.green;

    private void Start()
    {
        Animator = GetComponent<Animator>();

        shopScript = FindObjectOfType<ShopScript>();
        scoreForBreak = shopScript.GetScoreForBreak();

        stoneSpawnScript = FindObjectOfType<StoneSpawnScript>();
    }

    private void Update()
    {
        if (scoreForBreak <= 9)
        {
            gameObject.GetComponent<SpriteRenderer>().color = stoneSpawnScript.valueListMaterial[scoreForBreak-1];
        }
        else 
        {
            gameObject.GetComponent<SpriteRenderer>().color = stoneSpawnScript.valueListMaterial[stoneSpawnScript.valueListMaterial.Count-1];
        }
            
    }

}
