using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    private Scene _scene;

    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    public void TUNA()
    {
        SceneManager.LoadScene(_scene.buildIndex + 1);
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
