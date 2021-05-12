using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // detecting any collisions from other objects // 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Walls"))
        {
            Debug.Log("wall hit");
            DestroyEnemy();
        }
    }

    // destroy enemy object //
    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
