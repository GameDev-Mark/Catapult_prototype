using UnityEngine;

public class ForkLifterFunction : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;

    float armSpeed;
    Vector3 maxLeftHeight = new Vector3(-0.5f, 6f, 1.5f);
    Vector3 maxRightHeight = new Vector3(0.5f, 6f, 1.5f);
    Vector3 minLeftHeight = new Vector3(-0.5f, 0.25f, 1.5f);
    Vector3 minRightHeight = new Vector3(0.5f, 0.25f, 1.5f);

    // Start is called before the first frame update
    void Start()
    {
        armSpeed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        ArmMove();
        ArmMaxMinHeigh();
    }

    void ArmMove()
    {
        if (Input.GetMouseButton(0))
        {
            leftArm.transform.Translate(Vector3.up * armSpeed * Time.deltaTime);
            rightArm.transform.Translate(Vector3.up * armSpeed * Time.deltaTime);
        }
        if (Input.GetMouseButton(1))
        {
            leftArm.transform.Translate(Vector3.down * armSpeed * Time.deltaTime);
            rightArm.transform.Translate(Vector3.down * armSpeed * Time.deltaTime);
        }
    }

    void ArmMaxMinHeigh()
    {
        // freeze rotation and transform to one place // ?? they move and rotate and they should not ??
        if (leftArm.transform.position.y >= maxLeftHeight.y)
        {
            leftArm.transform.position = transform.position + maxLeftHeight;
            leftArm.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        if (rightArm.transform.position.y >= maxRightHeight.y)
        {
            rightArm.transform.position = transform.position + maxRightHeight;
            rightArm.transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }

        if (leftArm.transform.position.y <= minLeftHeight.y)
        {
            leftArm.transform.position = minLeftHeight;
        }
        if (rightArm.transform.position.y <= minRightHeight.y)
        {
            rightArm.transform.position = minRightHeight;
        }
    }
}
