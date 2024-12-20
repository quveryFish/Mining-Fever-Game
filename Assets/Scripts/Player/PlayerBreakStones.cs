using Unity.VisualScripting;
using UnityEngine;

public class PlayerBreakStones : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private StoneSpawnScript stonesSpawn;

    [SerializeField] private AudioSource breakSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<OreBreakScript>())
        {

            scoreManager.AddScore(collision.gameObject.GetComponent<OreBreakScript>().scoreForBreak);
            stonesSpawn.spawnList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            breakSound.Play();



        }
    }

}
