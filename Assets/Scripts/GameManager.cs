using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private void Awake()
    {
        if (_instance == null) {
            _instance = this;
        }
        DontDestroyOnLoad(this);
    }

    public static GameManager Instance()
    {
        return _instance;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Single);

    }

    public void RestartGame()
    {
        SceneManager.LoadScene("RestartScene", LoadSceneMode.Single);
        Cursor.lockState = CursorLockMode.None;
    }
}
