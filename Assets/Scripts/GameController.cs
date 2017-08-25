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

    // Update is called once per frame
    void Update ()
    {
        pointsOne.text = pointsPlayerOne.ToString();
        pointsTwo.text = pointsPlayerTwo.ToString();
    }
}
