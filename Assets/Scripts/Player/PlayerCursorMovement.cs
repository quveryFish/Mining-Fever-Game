using UnityEngine;

public class PlayerCursorMovement : MonoBehaviour
{
    [SerializeField] private int maxSpeed = 50;
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (Camera.main.ScreenToWorldPoint(mousePos).x < 9 &&
            Camera.main.ScreenToWorldPoint(mousePos).x > -9 &&
            Camera.main.ScreenToWorldPoint(mousePos).y < 4 &&
            Camera.main.ScreenToWorldPoint(mousePos).y > -5)
        {
            transform.position = Vector2.MoveTowards(transform.position,
            Camera.main.ScreenToWorldPoint(mousePos),
            maxSpeed * Time.deltaTime);
        }
        else
        {
            transform.position.Set(0, 0, 0);
        }
        Vector2 direction = new Vector2(
            Camera.main.ScreenToWorldPoint(mousePos).x,
            Camera.main.ScreenToWorldPoint(mousePos).y);
        transform.up = direction;
    }
}
