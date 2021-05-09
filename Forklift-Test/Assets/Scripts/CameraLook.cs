using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public GameObject forkLift;
    Vector3 camPos = new Vector3(0f, 7f, -8f);

    void Start()
    {
        transform.position = camPos;
    }

    void LateUpdate()
    {
        transform.LookAt(forkLift.transform);
    }
}
