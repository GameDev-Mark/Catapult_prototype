using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using TMPro;

public class GameCon : MonoBehaviour
{
    GameObject objectThrown;
    float objectsInPlay;
    public TMP_Text objectInPlayText;

    void Start()
    {
        objectsInPlay = 0f;

    }

    // unitys update function
    void Update()
    {
        objectThrown = GameObject.FindWithTag("ObjectThrown");

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }

        // check if object being thrown is active in hieracrhy // check if object is not in active in hierarchy, catch the null___________
        try
        {
            if(objectThrown.gameObject.activeInHierarchy)
                objectsInPlay++;
            Debug.Log("true");
        }
        catch(NullReferenceException) 
        {
            if (!objectThrown.gameObject.activeInHierarchy)
                objectsInPlay--;
            Debug.Log("null");
        }


    }
}
