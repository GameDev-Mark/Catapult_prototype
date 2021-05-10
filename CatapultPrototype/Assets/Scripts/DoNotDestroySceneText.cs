using UnityEngine;

public class DoNotDestroySceneText : MonoBehaviour
{
    void Update()
    { GameObject.DontDestroyOnLoad(this.gameObject);}
}
