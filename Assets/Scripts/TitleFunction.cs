using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleFunction : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        SceneManager.UnloadSceneAsync("Title");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
