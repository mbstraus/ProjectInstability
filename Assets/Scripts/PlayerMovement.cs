using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private bool IsCharacterMoving = false;
    private Vector2 MovementVector = Vector2.zero;
    private Rigidbody2D rb;

    [SerializeField]
    public float MovementSpeed = 5f;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + MovementVector * MovementSpeed * Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext callbackContext) {
        MovementVector = callbackContext.ReadValue<Vector2>();
        if (MovementVector == Vector2.zero) {
            IsCharacterMoving = false;
        } else {
            IsCharacterMoving = true;
        }
    }
}
