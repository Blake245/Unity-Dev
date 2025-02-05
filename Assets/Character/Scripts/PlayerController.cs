using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] PlayerData data;
    [SerializeField] Transform view;
    [SerializeField] Animator animator;

    [SerializeField] LayerMask groundLayerMask;

    CharacterController controller;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction sprintAction;
    Vector2 movementInput = Vector2.zero;
    Vector3 velocity = Vector3.zero;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        jumpAction = InputSystem.actions.FindAction("Jump");
        jumpAction.performed += OnJump;
        jumpAction.canceled += OnJump;

        sprintAction = InputSystem.actions.FindAction("Sprint");
        sprintAction.performed += OnSprint;
        sprintAction.canceled += OnSprintRelease;

        controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        Vector3 movement = new Vector3(movementInput.x, 0, movementInput.y);
        movement = Quaternion.AngleAxis(view.rotation.eulerAngles.y, Vector3.up) * movement;

        velocity.x = movement.x * data.speed;
        velocity.z = movement.z * data.speed;

        if (movement.sqrMagnitude > 0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * data.turnRate);
            //transform.forward = movement;
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * data.speed *Time.deltaTime);

        // Set Animator
        Vector3 v = velocity;
        v.y = 0;
        animator.SetFloat("Speed", v.magnitude);
        animator.SetFloat("YVelocity", controller.velocity.y);
        animator.SetBool("OnGround", controller.isGrounded);
        Debug.Log($"Speed: {v.magnitude}");
        //Debug.Log($"YVelocity: {controller.velocity.y}");
        //Debug.Log($"Onground: {controller.isGrounded}");
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed && controller.isGrounded)
        {
            //velocity.y = jumpForce;
            velocity.y = Mathf.Sqrt(-2 * data.gravity * data.jumpHeight);
        }
    }

    public void OnSprint(InputAction.CallbackContext ctx)
    {
        if (controller.isGrounded && data.speed == 1.33f)
        {
            data.speed = 3;
        }
    }
    public void OnSprintRelease(InputAction.CallbackContext ctx)
    {
        data.speed = 1.33f;
    }
}
