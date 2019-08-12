using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject ScoreUI;
    public GameObject finalScore;
    public GameObject GameOver;

    public int amountOfPlayers;

    public Player playerInFirst;

    public Player[] players = new Player[4];

    public CameraController cameraController;
    // Start is called before the first frame update
    void Start()
    {
        amountOfPlayers = AmountPlayers.GetAmountOfPlayers();
        switch (amountOfPlayers)
        {
            case 1:
                players[1].gameObject.SetActive(false);
                players[2].gameObject.SetActive(false);
                players[3].gameObject.SetActive(false);
                //players[1] = null;
                //players[2] = null;
                //players[3] = null;
                break;
            case 2:
                players[2].gameObject.SetActive(false);
                players[3].gameObject.SetActive(false);
                //players[2] = null;
                //players[3] = null;
                break;
            case 3:
                players[3].gameObject.SetActive(false);
                //players[3] = null;
                break;
            default:
                break;
        }
        playerInFirst = players[0];
        cameraController.SetPlayerInFirst(playerInFirst);
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (amountOfPlayers > 1)
        {
            foreach (Player p in players)
            {
                Debug.Log(playerInFirst.color.ToString());
                if (p.transform.position.x > playerInFirst.transform.position.x)
                {
                    playerInFirst = p;
                    cameraController.SetPlayerInFirst(playerInFirst);
                }

            }
        }
        ScoreUI.GetComponent<Text>().text = "Score  " + players[0].score +"\nScore  "+ players[1].score + "\nScore  " + players[2].score + "\nScore  " + players[3].score;
        int deadCount = 0;
        foreach(Player p in players)
        {
            if(p.alive == false)
            {
                Debug.Log(p.color.ToString() + " dead");
                deadCount++;
            }
        }
        if(deadCount == amountOfPlayers)
        {
            GameIsOver();
        }
    }

    void GameIsOver()
    {
        GameOver.gameObject.SetActive(true);
        finalScore.GetComponent<Text>().text = "Final Scores\n" + players[0].score + "\n" + players[1].score + "\n" + players[2].score + "\n" + players[3].score;
        ScoreUI.gameObject.SetActive(false);
    }
}
