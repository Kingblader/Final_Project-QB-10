using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Thanks to Brackeys for the Code
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
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

        if(direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSpeedTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * currentSpeed * Time.deltaTime);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
