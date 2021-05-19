using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class GameCon : MonoBehaviour
{
    GameObject[] objectThrown;

    //-----
    public List<GameObject> _LevelOne;
    public GameObject addTier;
    public GameObject SpawnLevelPos;

    GameObject levelOneTiersTAG;

    //-----
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
        ///
        levelOneTiersTAG = GameObject.FindWithTag("LevelOne_TierSpawn");
        ///

        objectThrown = GameObject.FindGameObjectsWithTag("ObjectThrown");
        objectInPlayText.text = "Objects " + objectThrown.Length + " / " + maxObjectsThrown;
        ammountSceneResetsText.text = "Resets " + amountSceneResets;

        if (objectThrown.Length >= maxObjectsThrown)
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

    // 
    public void NextLevel()
    {
        if (_LevelOne.Count == 1)
        {
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            _LevelOne.Add(addTier);
            Debug.Log("ADDED TIER 2");
        }
        else if (_LevelOne.Count == 2)
        {
            if (levelOneTiersTAG.activeInHierarchy)
            {
                Destroy(levelOneTiersTAG);
            }
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            Instantiate(_LevelOne[1], SpawnLevelPos.transform.position + new Vector3(0f, 3.5f, 0f), Quaternion.identity);
            _LevelOne.Add(addTier);
            Debug.Log("Spawn tier 2 & add tier 3");
        }
    }
}

