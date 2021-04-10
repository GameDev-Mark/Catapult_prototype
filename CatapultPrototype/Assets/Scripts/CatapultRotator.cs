using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultRotator : MonoBehaviour
{
    public GameObject endCatapult;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Vector3 xRotAngle = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            //xRotAngle.z = (xRotAngle.z > 180) ? xRotAngle.z - 360 : xRotAngle.z;

            transform.Rotate(xRotAngle * 4 * Time.deltaTime);
            Debug.Log("DOWN");
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 xRotAngle = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
            xRotAngle.z = (xRotAngle.z > 180) ? xRotAngle.z - 360 : xRotAngle.z;

            transform.Rotate(xRotAngle *- 4 * Time.deltaTime);
            Debug.Log("UP");
        }
    }
}
