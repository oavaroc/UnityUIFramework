using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathGame : PlayableGame
{
    private enum op
    {
        Add,
        Subtract,
        Divide,
        Multiply
    }
    [SerializeField]
    private TMP_InputField _input;
    [SerializeField]
    private TextMeshProUGUI _number1;
    [SerializeField]
    private TextMeshProUGUI _number2;
    [SerializeField]
    private TextMeshProUGUI _operator;
    [SerializeField]
    private Score _scoreText;


    private int _answer;
    private int _score = 0;
    private List<GameObject> test = new List<GameObject>();
    void Start()
    {
        NewGame();
        
        _score = 0;
    }


    public void NewGame()
    {
        _input.text = "";
        switch (RandomOperator())
        {
            case op.Add:
                CreateAddition();
                break;
            case op.Divide:
                CreateDivision();
                break;
            case op.Subtract:
                CreateSubtraction();
                break;
            case op.Multiply:
                CreateMultiply();
                break;

        }
        Debug.Log("Answer is: " + _answer);
        _input.Select();
    }

    public void CheckAnswer()
    {
        if (int.TryParse(_input.text, out int result))
        {
            if (_answer == result)
            {
                _scoreText.UpdateScore(++_score);
                NewGame();
            }
            else
            {
                //_output.text = "Incorrect, correct answer is : " + _answer;
                NewGame();
            }

        }
        else
        {
            //_output.text = "Please enter a number.";

        }
        //_input.Select();
    }

    private op RandomOperator()
    {
        return (op)Random.Range(0, 4);
    }

    private int RandomNumber()
    {
        return Random.Range(1, 99);
    }

    private void CreateAddition()
    {
        _operator.text = "+";
        int num1 = RandomNumber(); // First operand (factor)
        int num2 = RandomNumber();
        _number2.text = num2.ToString();
        _number1.text = num1.ToString();
        _answer = num1 + num2; // Update the answer
    }
    private void CreateDivision()
    {
        _operator.text = "/";
        int answer = RandomNumber(); //Generate the answer

        int num2 = RandomNumber(); // Generate the divisor (denominator)
        int num1 = num2 * answer; // Calculate the dividend (numerator) based on the answer and divisor

        _number1.text = num1.ToString();
        _number2.text = num2.ToString();
        _answer = answer; // Update the answer

    }
    private void CreateSubtraction()
    {
        _operator.text = "-";
        int num1 = RandomNumber(); // First operand (factor)
        int num2 = RandomNumber();
        _number2.text = num2.ToString();
        _number1.text = num1.ToString();
        _answer = num1 - num2; // Update the answer

    }
    private void CreateMultiply()
    {
        _operator.text = "*";
        int num1 = RandomNumber(); // First operand (factor)
        int num2 = RandomNumber(); // Second operand (multiplier)
        _number1.text = num1.ToString();
        _number2.text = num2.ToString();
        _answer = num1 * num2; // Update the answer

    }

    public override void HandleGameOver()
    {
        Debug.Log("Game Over!");
        _input.gameObject.SetActive(false);
        SaveManager.Instance.SaveHighScore(SaveManager.Game.MathGame, _score);
        _results.UpdateResults(SaveManager.Game.MathGame, _score);
        _results.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
