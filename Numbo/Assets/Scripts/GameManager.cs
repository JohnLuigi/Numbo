using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int problemNumber;
    public int sum = 0;
    public string pressedKey;
    public string solvedMessage;
    public int score = 0;



	// Use this for initialization
	void Start () {
        problemNumber = Random.Range(1, 11);
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("1"))
        {
            sum += 1;
        }

        if (Input.GetKeyUp("2"))
        {
            sum += 2;
        }

        if (Input.GetKeyUp("3"))
        {
            sum += 3;
        }

        // check if the player has added up to the number to solve
        // if right, add one to their score
        if (Input.GetKeyUp("return"))
        {
            if (sum == problemNumber)
            {                
                score++;
                solvedMessage = "Correct! Score: " + score;
                sum = 0;
                problemNumber = Random.Range(1, 11);
            }
        }

        if(Input.GetKeyUp("backspace"))
        {
            sum = 0;
        }

    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 30), "Solve: " + problemNumber);

        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + (Screen.height / 3), 100, 30), "Answer " + sum);

        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 - (Screen.height / 3), 100, 30), solvedMessage);

    }
}
