using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class GameCon : MonoBehaviour
{

    //-----
    public List<GameObject> _LevelOne; // level one list of objects to spawn
    public GameObject addTier; // level one tier to spawn
    public GameObject SpawnLevelPos; // level one , the starting position in which the first tier should spawn
    GameObject[] levelOneTiersTAG; // level one spawn TAG

    GameObject[] objectThrown; // objects that the catapult will throw

    public GameObject levelButton;

    GameObject[] enemyTag;

    //-----
    float levelsNumber; // current level number
    float maxObjectsThrown; // max amount of objects allowed
    float minObjectsThrown; // min amount of objects allowed

    //-----
    public TMP_Text objectInPlayText; // text for objects spawned
    public TMP_Text enemyCounterText; // current level text
    public TMP_Text currentLevelText; // current level text

    //-----
    SpawnObjects _spawnObjectsScript; // reference to spawnobjects script


    // unitys start function
    void Start()
    {
        levelsNumber = 1f;

        maxObjectsThrown = 3f;

        try
        {
            minObjectsThrown = 0f;
        }
        catch (MissingReferenceException) { }

        _spawnObjectsScript = GetComponentInParent<SpawnObjects>();
    }

    // unitys update function
    void Update()
    {
        //-----
        levelOneTiersTAG = GameObject.FindGameObjectsWithTag("LevelOne_TierSpawn"); // finding the tagged objects within the scene

        enemyTag = GameObject.FindGameObjectsWithTag("Enemy"); // finding the tagged object enemy" within the scene
        enemyCounterText.text = enemyTag.Length + " Enemies";
        //-----

        objectThrown = GameObject.FindGameObjectsWithTag("Projectile"); // finding the tagged objects within the scene
        objectInPlayText.text = "Projectiles " + objectThrown.Length + "/" + maxObjectsThrown; // displaying and updating the text of how many objects there is
        //-----

        currentLevelText.text = "Level : " + levelsNumber.ToString("F1");  // F1 == 1 decimal
        //-----

        if (objectThrown.Length >= maxObjectsThrown) // no more spawning of objects to throw when the max limit has been reached
            _spawnObjectsScript.enabled = false;
        else if(objectThrown.Length < maxObjectsThrown)
            _spawnObjectsScript.enabled = true;
        //-----

        if (Input.GetKeyDown(KeyCode.E)) //  restart scene 
            SceneManager.LoadScene(0);
        //-----

        if (enemyTag.Length == 0) // if no enemies are in the scene then can go to the next level
        {
            levelButton.gameObject.SetActive(true); // setting button to true 
        }
        //-----
    }

    // instantiating new levels/tiers and destorying old ones, the player progresses onto the next level/tier
    public void NextLevel()
    {
        //
        levelsNumber += 0.1f; // level text 
        //
        levelButton.gameObject.SetActive(false); // setting button to false when clicked
        //
        foreach (GameObject throwing in objectThrown) // destroy any remaining throwables in scene, ready for next level
            Destroy(throwing);
        //

        if (_LevelOne.Count == 1)
        {
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            _LevelOne.Add(addTier);
            if (levelOneTiersTAG.Length <= 1)
            {
                foreach (GameObject tiers in levelOneTiersTAG)
                    Destroy(tiers);
            }
        }
        else if (_LevelOne.Count == 2)
        {
            if (levelOneTiersTAG.Length <= 2)
            {
                foreach (GameObject tiers in levelOneTiersTAG)
                    Destroy(tiers);
            }
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            Instantiate(_LevelOne[1], SpawnLevelPos.transform.position + new Vector3(0f, 3.5f, 0f), Quaternion.identity);
            _LevelOne.Add(addTier);
        }
        else if (_LevelOne.Count == 3)
        {
            if (levelOneTiersTAG.Length <= 3)
            {
                foreach (GameObject tiers in levelOneTiersTAG)
                    Destroy(tiers);
            }
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            Instantiate(_LevelOne[1], SpawnLevelPos.transform.position + new Vector3(0f, 3.5f, 0f), Quaternion.identity);
            Instantiate(_LevelOne[2], SpawnLevelPos.transform.position + new Vector3(0f, 7f, 0f), Quaternion.identity);
            _LevelOne.Add(addTier);
        }
        else if (_LevelOne.Count == 4)
        {
            if (levelOneTiersTAG.Length <= 4)
            {
                foreach (GameObject tiers in levelOneTiersTAG)
                    Destroy(tiers);
            }
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            Instantiate(_LevelOne[1], SpawnLevelPos.transform.position + new Vector3(0f, 3.5f, 0f), Quaternion.identity);
            Instantiate(_LevelOne[2], SpawnLevelPos.transform.position + new Vector3(0f, 7f, 0f), Quaternion.identity);
            Instantiate(_LevelOne[3], SpawnLevelPos.transform.position + new Vector3(8f, 0f, 0f), Quaternion.identity);
            _LevelOne.Add(addTier);
        }
        else if (_LevelOne.Count == 5)
        {
            if (levelOneTiersTAG.Length <= 5)
            {
                foreach (GameObject tiers in levelOneTiersTAG)
                    Destroy(tiers);
            }
            Instantiate(_LevelOne[0], SpawnLevelPos.transform.position, Quaternion.identity);
            Instantiate(_LevelOne[1], SpawnLevelPos.transform.position + new Vector3(0f, 3.5f, 0f), Quaternion.identity);
            Instantiate(_LevelOne[2], SpawnLevelPos.transform.position + new Vector3(0f, 7f, 0f), Quaternion.identity);
            Instantiate(_LevelOne[3], SpawnLevelPos.transform.position + new Vector3(8f, 0f, 0f), Quaternion.identity);
            Instantiate(_LevelOne[4], SpawnLevelPos.transform.position + new Vector3(8f, 3.5f, 0f), Quaternion.identity);
            _LevelOne.Add(addTier);
        }
    }

    void LoseGame()
    {

    }
}

