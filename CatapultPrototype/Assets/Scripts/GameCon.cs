using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class GameCon : MonoBehaviour
{

    //-----
    [Header("GameObjects List")]
    public List<GameObject> _LevelOne; // level one list of objects to spawn

    [Header("GameObjects")]
    public GameObject addTier; // level one tier to spawn
    public GameObject SpawnLevelPos; // level one , the starting position in which the first tier should spawn
    GameObject[] levelOneTiersTAG; // level one spawn TAG

    GameObject[] projectiles; // objects that the catapult will throw
    GameObject[] enemyTag; // enemies within the scene

    public GameObject levelButton; // next level button
    public GameObject lostPanel; // lost panel , try again / exit button
    public GameObject panelBlocker;
    public GameObject resumeButton;

    //-----
    float levelsNumber; // current level number
    float maxProjectiles; // max amount of objects allowed
    float minProjectiles; // min amount of objects allowed

    //-----
    [Header("Texts")]
    public TMP_Text projectilesText; // text for objects spawned
    public TMP_Text enemyCounterText; // current level text
    public TMP_Text currentLevelText; // current level text

    //-----
    SpawnObjects _spawnObjectsScript; // reference to spawnobjects script


    // unitys start function
    void Start()
    {
        levelsNumber = 1f;

        maxProjectiles = 3f;

        try
        {
            minProjectiles = 0f;
        }
        catch (MissingReferenceException) { }

        _spawnObjectsScript = GetComponentInParent<SpawnObjects>();
    }

    // unitys update function
    void Update()
    {
        LoseGame(); // function for losing game

        //-----
        levelOneTiersTAG = GameObject.FindGameObjectsWithTag("LevelOne_TierSpawn"); // finding the tagged objects within the scene

        enemyTag = GameObject.FindGameObjectsWithTag("Enemy"); // finding the tagged object enemy" within the scene
        enemyCounterText.text = enemyTag.Length + " Enemies";
        //-----

        projectiles = GameObject.FindGameObjectsWithTag("Projectile"); // finding the tagged objects within the scene
        projectilesText.text = "Projectiles " + _spawnObjectsScript.projectileAmount + "/" + maxProjectiles; // displaying and updating the text of how many objects there is
        //-----

        currentLevelText.text = "Level : " + levelsNumber.ToString("F1");  // F1 == 1 decimal
        //-----

        if (_spawnObjectsScript.projectileAmount >= maxProjectiles) // no more spawning of objects to throw when the max limit has been reached
            _spawnObjectsScript.enabled = false;
        else if (_spawnObjectsScript.projectileAmount < maxProjectiles)
            _spawnObjectsScript.enabled = true;
        //-----

        if (enemyTag.Length == 0) // if no enemies are in the scene then can go to the next level
        {
            levelButton.gameObject.SetActive(true); // setting button to true 
        }
        //-----

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            lostPanel.SetActive(true);
            panelBlocker.SetActive(true);
            resumeButton.SetActive(true);
        }
    }

    // instantiating new levels/tiers and destorying old ones, the player progresses onto the next level/tier
    public void NextLevel()
    {
        //
        levelsNumber += 0.1f; // level text 
        //
        levelButton.gameObject.SetActive(false); // setting button to false when clicked
        //
        _spawnObjectsScript.projectileAmount = 0f;
        //
        foreach (GameObject _projectiles in projectiles)
            Destroy(_projectiles);
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

    // lose condition for the game, restart if player runs out of projectiles to throw and enemies are still standing, prompts lost panel
    void LoseGame()
    {
        if (_spawnObjectsScript.projectileAmount == maxProjectiles)
            foreach (GameObject _projectiles in projectiles)
                if (levelButton.activeInHierarchy || enemyTag.Length == 0)
                    lostPanel.SetActive(false);
                else if (!levelButton.activeInHierarchy && _projectiles != null)
                    lostPanel.SetActive(true); Debug.Log("HOW");
    }

    // attached to the try again button, restarts scene
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }

    // attached to the exit button, exits game
    public void ExitGame()
    {
        Application.Quit();
    }

    // attached to the resume button , resume the game from escape panel
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        lostPanel.SetActive(false);
        panelBlocker.SetActive(false);
        resumeButton.SetActive(false);
    }
}

