using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleFunction : MonoBehaviour
{
    public void StartGame(int amountOfPlayers)
    {
        AmountPlayers.SetAmountOfPlayers(amountOfPlayers);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
