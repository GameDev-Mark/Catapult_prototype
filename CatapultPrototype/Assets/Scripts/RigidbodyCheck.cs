using UnityEngine;

public class RigidbodyCheck : MonoBehaviour
{
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray rayDown = new Ray(transform.position, Vector3.down);
        Ray rayRight = new Ray(transform.position, Vector3.right);

        //if (Physics.Raycast(rayDown, out hit, 1f))
        //{
        //    if(hit.transform)
        //    {
        //        Debug.Log(hit.transform + "HIT");
        //    }
        //}
        if (Physics.Raycast(rayRight, out hit, 1f))
        {
            if (hit.collider)
            {
                Debug.Log(hit.collider + "HIT");
            }
        }
    }
}
