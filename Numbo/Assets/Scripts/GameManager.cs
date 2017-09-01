using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int goalNumber;
    public int sum = 0;
    public string pressedKey;
    public int score = 0;

    // GUI references
    public Text scoreText;
    public Text goalText;
    public Text answerText;




    // Set references to the GUI texts and initialize the first goal number
    void Start () {

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        goalText = GameObject.Find("GoalText").GetComponent<Text>();
        answerText = GameObject.Find("AnswerText").GetComponent<Text>();


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

        // update the GUI
        UpdateGUI();
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

    // update the GUI text to repsond to the player's input
    void UpdateGUI()
    {
        answerText.text = "Answer:\n" + sum;
        goalText.text = "Solve:\n" + goalNumber;
        scoreText.text = "Score: " + score;

        //TODO
        //    // display the rules on the side of the screen
        //    GUI.Button(new Rect(Screen.width * 0.75f, 0, 200, 400), "Use combinations of 1, 2, and 3 to solve for the number.\nPress enter to submit" +
        //    " your answer.\nWrong answers or going over the goal number will cost you a point.");
    }
}
