using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(CharacterController))]
public class PlayerContoroller : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    public Transform cameraTransform;

    private CharacterController controller;
    private Animator animator;
    private Vector3 velocity;
    private bool isGrounded;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;

        animator.SetBool("Grounded", isGrounded);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 move = cameraTransform.forward * vertical + cameraTransform.right * horizontal;
        move.y = 0f;
        move.Normalize();

        animator.SetBool("Run", move.magnitude > 0.1f);

        if (move.magnitude > 0.1f)
        {
            controller.Move(move * moveSpeed * Time.deltaTime);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move),
                10f * Time.deltaTime
            );
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}

    
    





