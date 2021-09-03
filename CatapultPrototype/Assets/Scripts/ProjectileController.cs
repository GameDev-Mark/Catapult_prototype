using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject explosionVFX;
    public AudioClip explosionSFX;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("Enemy"))
        {
            // to do : explode on impact
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1.5f);
            foreach(Collider hit in colliders)
            {
                Rigidbody enemyRB = hit.GetComponent<Rigidbody>();

                if(enemyRB != null)
                {
                    enemyRB.AddExplosionForce(225f, transform.position, 1.5f, 4f);

                    GameObject exploVFX = Instantiate(explosionVFX, transform.position, Quaternion.identity);
                    AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, 0.3f);
                    Destroy(exploVFX, 1f);
                    Destroy(gameObject);
                }
            }
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            GameObject exploVFX = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, 0.3f);
            Destroy(exploVFX, 1f);
            Destroy(gameObject);
        }
    }
}