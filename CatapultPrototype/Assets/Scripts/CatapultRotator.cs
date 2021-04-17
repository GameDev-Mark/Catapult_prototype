using UnityEngine;

public class CatapultRotator : MonoBehaviour
{
    int catapultForwardRotSpeed;
    int catapultReverseRotSpeed;
    int speedIncrease;

    bool slowSpeed;

    // unitys start function
    void Start()
    {
        catapultForwardRotSpeed = 40;
        catapultReverseRotSpeed = 30;
        speedIncrease = 3;
    }

    // Update is called once per frame
    void Update()
    {
        CatapultRotating();
    }

    // rotating the catapult arm , shooting and resetting
    public void CatapultRotating()
    {
        Vector3 zRotAngle = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z); // ref to rotations
        Vector3 zTopRotAngle = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -90f); // when rotator reaches top 
        Vector3 zBotRotAngle = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 20f); // when rotator reaches bottom 
        zRotAngle.z = (zRotAngle.z > 180) ? zRotAngle.z - 360 : zRotAngle.z; // lets the angle be rotated accordinaly 

        Debug.Log(catapultForwardRotSpeed);
        if (Input.GetMouseButton(1)) // CATAPULT GO DOWN
        {
            transform.RotateAround(transform.position, Vector3.forward, catapultReverseRotSpeed * Time.deltaTime);
        }
        else if(zRotAngle.z <= -90f)
        {
            transform.localEulerAngles = zTopRotAngle;
        }

        if (Input.GetMouseButton(0)) // CATAPULT GO UP
        {
            canClickMouse = true;
            catapultForwardRotSpeed += speedIncrease;
            transform.RotateAround(transform.position, Vector3.back, catapultForwardRotSpeed * Time.deltaTime);
        }
        else if (zRotAngle.z >= 20f)
        {
            transform.localEulerAngles = zBotRotAngle;
            canClickMouse = false;

        }
        else if (canClickMouse == false)
        {
            catapultForwardRotSpeed = 40;
        }
    }
}
