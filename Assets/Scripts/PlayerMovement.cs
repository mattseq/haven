using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private InputActionAsset inputAsset;
    private InputAction moveAction;
    private InputAction jumpAction;
    private Vector2 velocity;
    Rigidbody2D rb;

    public Transform wallLeft;
    public Transform wallRight;
    public Transform ground;

    float dist = 0.001f;

    private BoxCollider2D boxCollider;

    private bool canDash = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inputAsset = InputSystem.actions;
        moveAction = inputAsset.FindAction("Move");
        jumpAction = inputAsset.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int notPlayerMask = ~(LayerMask.GetMask("Player") | LayerMask.GetMask("Ignore Raycast"));
        RaycastHit2D wallLeftHit = Physics2D.Raycast(wallLeft.position, -transform.right, dist);
        RaycastHit2D wallRightHit = Physics2D.Raycast(wallRight.position, transform.right, dist);
        RaycastHit2D groundHit = Physics2D.Raycast(ground.position, -transform.up, dist);

        if (wallRightHit) {
          Debug.Log(wallRightHit.distance);
        }
        if (wallLeftHit) {
          Debug.Log(wallLeftHit.distance);
        }
        
        if (!wallLeftHit && !wallRightHit && groundHit) {
          Vector2 moveValue = moveAction.ReadValue<Vector2>();

          rb.linearVelocity = new Vector2(moveValue.x, rb.linearVelocity.y);
        }

        if (groundHit) {
          Debug.Log("Ground");

          // jump
          if (jumpAction.WasPressedThisFrame()) {
            Debug.Log("Jump");
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y + 5.0f);
          }

          canDash = true;
        }

        // if (canDash && ) {
        //
        // }

    }
}
