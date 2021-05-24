using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject, 2f);
        }
    }
}
