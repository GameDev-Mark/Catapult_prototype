using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float camSideMoveSpeed; // speed of camera moving
    float camInandOutSpeed;

    Vector3 camPos;
    Vector3 camMinPos;
    Vector3 camMaxPos;
    Vector3 camSideMinPos;
    Vector3 camSideMaxPos;

    // unitys start function
    void Start()
    {
        camSideMoveSpeed = 20f;
        camInandOutSpeed = 10f;

        transform.position = new Vector3(0f, 8f, -18f);
    }

    // unitys update function
    void Update()
    {
        MoveInandOut();
        MoveSideToSide();

        camPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Q)) // move camera to catapult
        {
            transform.position = new Vector3(0f, 8f, -18f);
        }
    }

    // move camera inwards and outwards
    void MoveInandOut()
    {
        camMinPos = new Vector3(transform.position.x, transform.position.y, -16f);
        camMaxPos = new Vector3(transform.localPosition.x, transform.localPosition.y, -30f);

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            if (camPos.z >= -16f)
            {
                transform.position = camMinPos;
            }
            if (Input.GetKey(KeyCode.S)) // move outwards
            {
                transform.Translate(Vector3.back * camInandOutSpeed * Time.deltaTime);
            }
            if (camPos.z <= -30)
            {
                transform.position = camMaxPos;
            }
            if (Input.GetKey(KeyCode.W)) // move inwards
            {
                transform.Translate(Vector3.forward * camInandOutSpeed * Time.deltaTime);
            }
        }
    }

    // move camera left and right
    void MoveSideToSide()
    {
        camSideMinPos = new Vector3(0f, transform.position.y, transform.position.z);
        camSideMaxPos = new Vector3(30f, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
           if(camPos.x <= 0f)
            {
                transform.position = camSideMinPos;
            }
            if (Input.GetKey(KeyCode.D)) // move right
            {
                transform.Translate(Vector3.right * camSideMoveSpeed * Time.deltaTime);
            }
            if (camPos.x >= 30f)
            {
                transform.position = camSideMaxPos;
            }
            if (Input.GetKey(KeyCode.A)) // move left
            {
                transform.Translate(Vector3.left * camSideMoveSpeed * Time.deltaTime);
            }
        }
    }
}
