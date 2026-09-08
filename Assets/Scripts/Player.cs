using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera cam;

    public InputActionReference moveAction;
    public Vector2 movement;
    public Vector2 mousePos;

    // Update is called once per frame
    void Update()
    {
        movement = moveAction.action.ReadValue<Vector2>();
        mousePos = cam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    // Fixed update is every 0.02 seconds,
    // keeping movement the same across framerates
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
