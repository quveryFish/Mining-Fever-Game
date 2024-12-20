using UnityEngine;

public class PlayerCursorMovement : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 50;
    void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < 9 &&
            Camera.main.ScreenToWorldPoint(Input.mousePosition).x > -9 &&
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y < 4 &&
            Camera.main.ScreenToWorldPoint(Input.mousePosition).y > -5)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            Camera.main.ScreenToWorldPoint(Input.mousePosition),
            maxSpeed * Time.deltaTime);
        }
        else
        {
            transform.position.Set(0, 0, 0);
        }

    }
}
