using UnityEngine;

public class CameraMove : MonoBehaviour
{
    float camMoveSpeed; // speed of camera moving
    float camScrollSpeed;
    Vector3 camPos;
    Vector3 camMinPos;
    Vector3 camMaxPos;

    // unitys start function
    void Start()
    {
        camMoveSpeed = 10f;
        camScrollSpeed = 25f;
        //camPos = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        //camMinPos = new Vector3(transform.localPosition.x, transform.localPosition.y, -9f);
        camMaxPos = new Vector3(transform.localPosition.x, transform.localPosition.y, -20f);
    }
    
    // unitys lateupdate function
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.D)) // move to the right
        {
            transform.Translate(Vector3.right * camMoveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) // move to the left
        {
            transform.Translate(Vector3.left * camMoveSpeed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.Q)) // move camera to catapult
        {
            transform.position = new Vector3(0f, 8f, -9f);
        }
    }

    // unitys update function
    void Update()
    {
        camPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        camMinPos = new Vector3(transform.position.x, transform.position.y, -9f);

        if (Input.GetAxis("Mouse ScrollWheel" ) < 0f) // scroll out
        {
            camScrollSpeed = 25f;
            transform.Translate(Vector3.back * camScrollSpeed * Time.deltaTime);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // scroll in
        {
            camScrollSpeed = 25f;
            transform.Translate(Vector3.forward * camScrollSpeed * Time.deltaTime);
        }
        else if (camPos.z >= -9f)
        {
            transform.position = camMinPos;
            camScrollSpeed = 0f;
            Debug.Log("-9");
        }

        //if (camPos.z >= -20f)
        //{
        //    transform.position = camMaxPos;
        //}
    }

}
