using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCon : MonoBehaviour
{
    // unitys update function
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }
}
