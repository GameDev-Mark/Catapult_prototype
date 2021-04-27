using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectThrownPrefab; // prefab to spawn

    Vector3 prefabSpawnLocation = new Vector3(-3.30f, 8f, 0f); // postion of prefab spawning

    // unitys update function
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) // press F key to spawn prefab
        {
            Instantiate(objectThrownPrefab, prefabSpawnLocation, Quaternion.identity);
        }
    }
}
