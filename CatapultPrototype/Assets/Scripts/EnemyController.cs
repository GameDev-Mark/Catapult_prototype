using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // detecting any collisions from other objects // 
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("Walls") || collision.gameObject.CompareTag("ObjectThrown"))
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
