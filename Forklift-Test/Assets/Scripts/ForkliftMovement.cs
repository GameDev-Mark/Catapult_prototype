using UnityEngine;

public class ForkliftMovement : MonoBehaviour
{
    Rigidbody rb;

    float rotationSpeed;
    float forwardSpeed;
    float backwardsSpeed;

    // unitys start function
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();

        rotationSpeed = 9f;
        forwardSpeed = 2f;
        backwardsSpeed = 1f;
    }

    // unitys fixedupdate function
    void FixedUpdate()
    {
        // rotate left //
        Quaternion turnLeft = Quaternion.Euler(0f, -10f, 0f);
        turnLeft.y *= Time.fixedDeltaTime * rotationSpeed;

        if (Input.GetKey(KeyCode.A))
        {
            rb.MoveRotation(rb.rotation * turnLeft);
        }

        // rotate right //
        Quaternion turnRight = Quaternion.Euler(0f, 10f, 0f);
        turnRight.y *= Time.fixedDeltaTime * rotationSpeed;

        if (Input.GetKey(KeyCode.D))
        {
            rb.MoveRotation(rb.rotation * turnRight);
        }

        // move forwards //
        Vector3 moveForward = transform.TransformDirection(Vector3.forward);
        moveForward *= Time.fixedDeltaTime * forwardSpeed;

        if (Input.GetKey(KeyCode.W))
        {
            rb.MovePosition(transform.position + moveForward);
            forwardSpeed += 0.06f;
        }
        else
        {
            forwardSpeed = 2f;
        }

        // move backwards //
        Vector3 moveBack = transform.TransformDirection(Vector3.back);
        moveBack *= Time.fixedDeltaTime * backwardsSpeed;

        if (Input.GetKey(KeyCode.S))
        {
            rb.MovePosition(transform.position + moveBack);
        }
    }
}
