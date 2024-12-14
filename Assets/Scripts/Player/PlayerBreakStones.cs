using Unity.VisualScripting;
using UnityEngine;

public class PlayerBreakStones : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private StoneSpawnScript stonesSpawn;

    public int scoreForBreak =1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ore"))
        {
            stonesSpawn.spawnList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            scoreManager.AddScore(scoreForBreak);

        }
    }

}
