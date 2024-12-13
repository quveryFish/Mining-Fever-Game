using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 movementDirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = movementDirection * speed;
    }
}
