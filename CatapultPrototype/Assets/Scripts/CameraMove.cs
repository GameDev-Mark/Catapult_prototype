using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float camSideMoveSpeed; // speed move side to side
    float camInandOutSpeed; // speed move forwards and backwards

    Vector3 camPos; // reference to camera position
    Vector3 camStartPos; // reference to start postion of camera

    // unitys start function
    void Start()
    {
        camSideMoveSpeed = 20f;
        camInandOutSpeed = 10f;

        camStartPos = new Vector3(0f, 8f, -16f);
        transform.position = camStartPos;
    }

    // unitys Fixedupdate function
    void FixedUpdate()
    {
        MoveInandOut();
        MoveSideToSide();

        camPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        if (Input.GetKeyDown(KeyCode.Q)) // move camera to catapult
        {
            transform.position = camStartPos;
        }
    }

    // move camera inwards and outwards
    void MoveInandOut()
    {

        if (Input.GetKey(KeyCode.A) == false && Input.GetKey(KeyCode.D) == false)
        {
            if (camPos.z > -16f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -16f);
                Debug.Log("forward");
            }
            if (Input.GetKey(KeyCode.S)) // move outwards
            {
                transform.Translate(Vector3.back * camInandOutSpeed * Time.deltaTime, Space.World);
            }
            if (camPos.z < -30)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -30f);
            }
            if (Input.GetKey(KeyCode.W)) // move inwards
            {
                transform.Translate(Vector3.forward * camInandOutSpeed * Time.deltaTime, Space.World);
            }
        }
    }

    // move camera left and right
    void MoveSideToSide()
    {
        if (Input.GetKey(KeyCode.W) == false && Input.GetKey(KeyCode.S) == false)
        {
           if(camPos.x < -1f)
            {
                transform.position = new Vector3(-1f, transform.position.y, transform.position.z);
                Debug.Log("Lefty");
            }
            if (Input.GetKey(KeyCode.D)) // move right
            {
                transform.Translate(Vector3.right * camSideMoveSpeed * Time.deltaTime);
            }
            if (camPos.x > 30f)
            {
                transform.position = new Vector3(30f, transform.position.y, transform.position.z);
            }
            if (Input.GetKey(KeyCode.A)) // move left
            {
                transform.Translate(Vector3.right * -camSideMoveSpeed * Time.deltaTime);
            }
        }
    }
}