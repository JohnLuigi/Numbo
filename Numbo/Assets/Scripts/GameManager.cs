using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int goalNumber;
    public int sum = 0;
    public string pressedKey;
    public int score = 0;



	// Use this for initialization
	void Start () {
        goalNumber = Random.Range(1, 11);
	}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp("1"))
        {
            TestSum(1);
        }

        if (Input.GetKeyUp("2"))
        {
            TestSum(2);
        }

        if (Input.GetKeyUp("3"))
        {
            TestSum(3);
        }

        // check if the player has added up to the number to solve
        // if right, add one to their score
        if (Input.GetKeyUp("return"))
        {
            if (sum == goalNumber)
            {                
                score++;
                sum = 0;
                goalNumber = Random.Range(1, 11);
            }
            // if the wrong answer is submitted, subtract from the score
            // but don't subtract from the score if no answer has been entered
            else if (sum != 0)
            {
                score--;
                // TODO
                // add some sort of visual indication that the wrong answer was submitted
            }
        }

        if(Input.GetKeyUp("backspace"))
        {
            sum = 0;
        }

    }

    void OnGUI()
    {
        // display the number to solve
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 100, 30), "Solve: " + goalNumber);

        // display the working sum
        GUI.Label(new Rect(Screen.width / 2, Screen.height / 2 + (Screen.height / 3), 100, 30), "Answer " + sum);

        // display the score at the top of the screen
        GUI.Label(new Rect(0, 0, 200, 30), "Score: " + score);

        // display the rules on the side of the screen
        GUI.Label(new Rect(Screen.width * 0.75f, 0, 200, 400), "Use combinations of 1, 2, and 3 to solve for the number.\nPress enter to submit" +
        " your answer.\nWrong answers or going over the goal number will cost you a point.");

    }

    // check if the working sum goes over the goal number, if it does, subtract from the score
    // TODO display a message saying something
    void TestSum(int value)
    {
        if(sum + value > goalNumber)
        {
            score--;
            // TODO add the warning message 
            // maybe reset the sum to 0 so if the player goes over it they have to start over?
            sum = 0;
        }
        else
        {
            sum += value;
        }
    }
}
