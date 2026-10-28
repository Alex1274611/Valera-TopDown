using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControoler : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    InputAction moveAction;
    Animator animator;
    public float rotationOffset;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
        animator = GetComponent<Animator>();
    }
    private void Move()
    {
        Vector2 moveVector = moveAction.ReadValue<Vector2>();
        rb.linearVelocity = moveVector * speed;
        animator.SetFloat("speed", rb.linearVelocity.sqrMagnitude);
    }
    void FixedUpdate()
    {
        Move();
        RotatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RotatePlayer()
    {
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector2 direction = (mouseWorldPos - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + rotationOffset);
    }
}
