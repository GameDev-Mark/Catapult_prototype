using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectThrownPrefab; // prefab to spawn
    public GameObject catapultHandPos; // catapult hand gameobject
    public GameObject spawnerPosition;

    [SerializeField] public float projectileAmount;

    void Start()
    {
        projectileAmount = 0f;
    }

    // unitys update function
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) // press F key to spawn prefab
        {
            Instantiate(objectThrownPrefab, spawnerPosition.transform.position, Quaternion.identity);
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F)) // press F key to spawn prefab
        {
            projectileAmount++;
        }
    }
}
