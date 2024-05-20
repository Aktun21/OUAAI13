using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private Scene _scene;
    [SerializeField] private int SceneIndex;
    private void Awake()
    {
        _scene = SceneManager.GetActiveScene();
    }

    public void TUNA()
    {
        SceneManager.LoadScene(SceneIndex);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
