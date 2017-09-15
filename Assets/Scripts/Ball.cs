using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float startSpeed = 5f;
    public float waitTimer;

    public Color color;

    float currentTimer;
    float currentSpeed;

    float randomY;

    Vector3 startPostition;
    Vector3 ballMovement;

    GameController gc;
    MeshRenderer meshRenderer;
    

    private void Start()
    {
        gc = FindObjectOfType<GameController>();
    }

    void Awake ()
    {
        startPostition = transform.position;

        ballMovement = transform.position;

        meshRenderer = GetComponent<MeshRenderer>();

        meshRenderer.sharedMaterial.color = color;

        ResetBall();
    }

    void FixedUpdate ()
    {
        Movement();
	}

    void Movement()
    {
        if (currentTimer > 0)
        {
            currentTimer -= Time.deltaTime;
            return;
        }

        ballMovement = transform.position;

        ballMovement.x = currentSpeed;
        ballMovement.y = randomY;

        transform.position += ballMovement * Time.deltaTime;
    }

    void ResetBall()
    {
        transform.position = startPostition;
        currentTimer = waitTimer;
        currentSpeed = startSpeed;
        meshRenderer.sharedMaterial.color = color;
        randomY = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            currentSpeed = -currentSpeed;

            randomY = Random.Range(-5, 6);

            if(currentSpeed >= 0)
            {
                currentSpeed += 0.5f;
            }
            else
            {
                currentSpeed -= 0.5f;
            }

            if (collision.transform == gc.rendererPlayerTwo.transform)
            {
                meshRenderer.sharedMaterial.color = gc.rendererPlayerTwo.material.color;
            }
            else if(collision.transform == gc.rendererPlayerOne.transform)
            {
                meshRenderer.sharedMaterial.color = gc.rendererPlayerOne.material.color;
            }

        }
        else
        {
            randomY = -randomY;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Out")
        {
            ResetBall();

            if(other.transform == gc.right)
            {
                gc.pointsPlayerOne++;
                
            }
            else if(other.transform == gc.left)
            {
                gc.pointsPlayerTwo++;
            }
        }
    }
}
