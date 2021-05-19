using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectThrownPrefab; // prefab to spawn
    public GameObject catapultHandPos; // catapult hand gameobject

    Vector3 prefabSpawnLocation; // where to spawn objects

    void Start()
    {
        prefabSpawnLocation = new Vector3(catapultHandPos.transform.position.x, 5f, catapultHandPos.transform.position.z); // postion of prefab spawning
    }

    // unitys update function
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) // press F key to spawn prefab
        {
            Instantiate(objectThrownPrefab, prefabSpawnLocation, Quaternion.identity);
        }
    }
}
