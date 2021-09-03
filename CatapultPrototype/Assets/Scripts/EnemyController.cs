using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject enemyExplodeVFX;

    // detecting any collisions from other objects // 
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("ObjectThrown"))
        {
            GameObject explodingVFX = Instantiate(enemyExplodeVFX, transform.position, Quaternion.identity);
            Destroy(explodingVFX, 1f);
            DestroyEnemy();
        }
    }

    // destroy enemy object //
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}