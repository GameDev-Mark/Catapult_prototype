using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameCon : MonoBehaviour
{
    GameObject[] objectThrown;

    float maxObjectsThrown;
    float minObjectsThrown;
    int amountSceneResets;

    public TMP_Text objectInPlayText;
    public TMP_Text ammountSceneResetsText;

    SpawnObjects _spawnObjectsScript;

    // unitys start function
    void Start()
    {
        maxObjectsThrown = 3f;
        minObjectsThrown = 0f;

        _spawnObjectsScript = GetComponentInParent<SpawnObjects>();
    }

    // unitys update function
    void Update()
    {
        objectThrown = GameObject.FindGameObjectsWithTag("ObjectThrown");
        objectInPlayText.text = "Objects " + objectThrown.Length + " / " + maxObjectsThrown;
        ammountSceneResetsText.text = "Resets " + amountSceneResets;

        if(objectThrown.Length >= maxObjectsThrown)
        {
            _spawnObjectsScript.enabled = false;
        }

        // restart scene ---------------
        if (Input.GetKeyDown(KeyCode.E))
        {
            amountSceneResets++;
            SceneManager.LoadScene(0);
        }
    }
}

