using UnityEngine;
using UnityEngine.EventSystems;

public class CatapultRotator : MonoBehaviour
{
    int catapultForwardRotSpeed; // forward rotation speed
    int catapultReverseRotSpeed; // backwards rotation speed
    int speedIncrease; // how much speed increases

    Rigidbody rb; // rigidbody component

    public AudioSource audioSource;
    public AudioClip projectileThrowSFX;

    // unitys start function
    void Start()
    {
        catapultForwardRotSpeed = 5;
        catapultReverseRotSpeed = 5;
        speedIncrease = 13;

        rb = GetComponent<Rigidbody>();

        

        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }
 
    // unitys fixed update
    void FixedUpdate()
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

        Vector3 zForward = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, -2f); // ref to rotations , Z rotation (forward) 
        Quaternion forwardRotation = Quaternion.Euler(zForward * catapultForwardRotSpeed * Time.deltaTime); // calculating angle (forward)

        Vector3 zBackwards = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 3f); // ref to rotations , Z rotation (backwards) 
        Quaternion backwardsRotation = Quaternion.Euler(zBackwards * catapultReverseRotSpeed * Time.deltaTime); // calculating angle (backwards)

        // CATAPULT GO DOWN
        if (Input.GetMouseButton(1)) 
        {
            rb.MoveRotation(rb.rotation * backwardsRotation);
        }
        if (zRotAngle.z >= 20f)
        {
            transform.localEulerAngles = zBotRotAngle;
            catapultReverseRotSpeed = 0;
        }

        // CATAPULT GO UP
        if (Input.GetMouseButton(0)) 
        {
            if (EventSystem.current.IsPointerOverGameObject()) 
                return;

            catapultForwardRotSpeed += speedIncrease;
            rb.MoveRotation(rb.rotation * forwardRotation);
        }
        if (zRotAngle.z <= -90f)
        {
            transform.localEulerAngles = zTopRotAngle;
            catapultForwardRotSpeed = 0;
        }

        if(zRotAngle.z <= -70f)
        {
            // TO DO  : play sound when releasing projectile
            //audioSource.PlayOneShot(projectileThrowSFX);
            //Debug.Log("PLAY SOUND");
        }

        // if not key is pressed down then reset speeds
        if (!Input.anyKey)
        {
            catapultForwardRotSpeed = 5;
            catapultReverseRotSpeed = 10;
        }
    }
}