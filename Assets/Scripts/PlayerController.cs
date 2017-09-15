using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public enum PlayerNr
    {
        PlayerOne,
        PlayerTwo,
        AI
    }

    public PlayerNr playerNr;

    public float speed;
    float playerMovement;
    public Ball ball;


	// Use this for initialization
	void Awake ()
    {
        playerNr = (PlayerNr)PlayerPrefs.GetInt("Player1");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(playerNr == PlayerNr.PlayerOne)
        {
            playerMovement = Input.GetAxis("VerticalPlayer1");
        }
        else if(playerNr == PlayerNr.PlayerTwo)
        {
            playerMovement = Input.GetAxis("VerticalPlayer2");
        }      

	}

    private void FixedUpdate()
    {
        Vector3 movement = transform.position;

        if (playerNr != PlayerNr.AI)
        {
            movement.y += playerMovement * speed * Time.deltaTime;

            movement.y = Mathf.Clamp(movement.y, -3.5f, 3.5f);

            transform.position = movement;
        }
        else
        {
            movement.y = Mathf.Lerp(movement.y, ball.transform.position.y, speed * Time.deltaTime);

            movement.y = Mathf.Clamp(movement.y, -3.5f, 3.5f);

            transform.position = movement;
        }
    }
}
