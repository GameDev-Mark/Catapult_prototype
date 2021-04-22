using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject objectThrown;

    // Start is called before the first frame update
    void Start()
    {
        objectThrown = GameObject.FindWithTag("ObjectThrown");
    }

    
    void LateUpdate()
    {
        transform.position = objectThrown.transform.position + new Vector3(0f, 5f, -9f);
    }
}
