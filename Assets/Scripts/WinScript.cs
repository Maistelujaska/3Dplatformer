using UnityEngine;

public class WinScript : MonoBehaviour
{
    private SceneChanger sceneScript;
    void Start()
    {
        sceneScript = GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<SceneChanger>();
    }
}
