using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameOver)
        {
            rb.linearVelocity = Vector2.zero; 
            return;
        }
    } 

    void FixedUpdate()
    {
        if (GameManager.instance != null && GameManager.instance.IsGameOver)
                return;

        rb.linearVelocity = moveInput * speed;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
