using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int pointsPlayerOne;
    public int pointsPlayerTwo;

    public Text pointsOne;
    public Text pointsTwo;

    public Transform left, right;

    public MeshRenderer rendererPlayerOne, rendererPlayerTwo;

    public PlayerController player1, player2;

    private void Start()
    {
        switch(PlayerPrefs.GetInt("Game"))
        {
            case 0:
                    player1.playerNr = PlayerController.PlayerNr.PlayerOne;
                    player2.playerNr = PlayerController.PlayerNr.PlayerTwo;
                break;
            case 1:
                player1.playerNr = PlayerController.PlayerNr.PlayerOne;
                player2.playerNr = PlayerController.PlayerNr.AI;
                break;
            case 2:
                player1.playerNr = PlayerController.PlayerNr.AI;
                player2.playerNr = PlayerController.PlayerNr.AI;
                break;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        pointsOne.text = pointsPlayerOne.ToString();
        pointsTwo.text = pointsPlayerTwo.ToString();
    }
}
