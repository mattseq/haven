using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputActionAsset inputAsset;
    private InputAction moveAction;
    private Vector2 velocity;
    Rigidbody2D rb;

    private BoxCollider2D boxCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputAsset = InputSystem.actions;
        moveAction = inputAsset.FindAction("Move");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        rb.linearVelocity = new Vector2(moveValue.x, rb.linearVelocity.y);

        Debug.Log(moveValue.x);
    }
}
