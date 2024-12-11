using Unity.VisualScripting;
using UnityEngine;

public class PlayerBreakStones : MonoBehaviour
{
    [SerializeField] private StoneSpawnScript stonesSpawn;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ore"))
        {
            stonesSpawn.spawnList.Remove(collision.gameObject);
            Destroy(collision.gameObject);

        }
    }

}
