using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Thanks to Brackeys for the Code
public class ThirdPersonController : MonoBehaviour
{
    [Header("Reference")]
    public CharacterController controller;
    public Transform cam;

    public float baseSpeed;
    public float sprintSpeed;
    private float currentSpeed;

    public float gravity = -9.81f;

    Vector3 velocity;

    public float turnSpeedTime = 0.1f;
    float turnSmoothVelocity;

    public Animator animator;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        currentForm = Form.Form1; // Initial form
        EnableMovement(true); // Enable movement initially
    }

    void Update()
    {
        if (currentForm == Form.Form1)
        {
            HandleMovement();
        }
        HandleSwitchForm();
    }

    private void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed + sprintSpeed;
        }
        else
        {
            currentSpeed = baseSpeed;
        }

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeedTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * currentSpeed * Time.deltaTime);
        }

        if (horizontal != 0f || vertical != 0f)
        {
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Active");
        }
    }

    private void HandleSwitchForm()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchForm();
        }
    }

    private void SwitchForm()
    {
        if (currentForm == Form.Form1)
        {
            currentForm = Form.Form2;
            animator.SetTrigger("ToForm2"); // Trigger animation to Form2
            EnableMovement(false); // Disable movement
        }
        else
        {
            currentForm = Form.Form1;
            animator.SetTrigger("ToForm1"); // Trigger animation to Form1
            EnableMovement(true); // Enable movement
        }
        Debug.Log("Switched to form: " + currentForm);
    }

    private void EnableMovement(bool isEnabled)
    {
        controller.enabled = isEnabled; // Enable/Disable CharacterController
    }

    private enum Form
    {
        Form1,
        Form2
    }

    private Form currentForm;
}
