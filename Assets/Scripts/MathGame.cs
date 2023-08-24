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
    /* Summary: Starts a new math game and initializes the score to 0
     * 
     */
    void Start()
    {
        NewGame();
        
        _score = 0;
    }


    /* Summary: Determines a mathematical operator to create a problem for, then sets the input field to active
     * 
     */
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
        _input.ActivateInputField();
    }

    /* Summary: returns a random operator
     * 
     */
    private op RandomOperator()
    {
        return (op)Random.Range(0, 4);
    }
    /* Summary: Creates a random addition math problem using random numbers
     * 
     */
    private void CreateAddition()
    {
        _operator.text = "+";
        int num1 = RandomNumber(); // First operand (factor)
        int num2 = RandomNumber();
        _number2.text = num2.ToString();
        _number1.text = num1.ToString();
        _answer = num1 + num2; // Update the answer
    }
    /* Summary: Creates a random division math problem using random numbers
     * 
     */
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
    /* Summary: Creates a random subtraction math problem using random numbers
     * 
     */
    private void CreateSubtraction()
    {
        _operator.text = "-";
        int num1 = RandomNumber(); // First operand (factor)
        int num2 = RandomNumber();
        _number2.text = num2.ToString();
        _number1.text = num1.ToString();
        _answer = num1 - num2; // Update the answer

    }
    /* Summary: Creates a random multiplication math problem using random numbers
     * 
     */
    private void CreateMultiply()
    {
        _operator.text = "*";
        int num1 = RandomNumber(); // First operand (factor)
        int num2 = RandomNumber(); // Second operand (multiplier)
        _number1.text = num1.ToString();
        _number2.text = num2.ToString();
        _answer = num1 * num2; // Update the answer

    }
    /* Summary: generates a random number between 1 and 99
     * 
     * returns:
     * int : random number from 1 to 99
     */
    private int RandomNumber()
    {
        return Random.Range(1, 99);
    }
    /* Summary: run when the player submits via input field. Checks the answer given with what it should be
     * 
     */
    public void CheckAnswer()
    {
        if (int.TryParse(_input.text, out int result))
        {
            if (_answer == result)
            {
                _scoreText.UpdateScore(++_score);
                AudioManager.Instance.PlayMathCorrect();
                NewGame();
            }
            else
            {
                AudioManager.Instance.PlayMathWrong();
                NewGame();
            }

        }
    }

    /* Summary: Disables the input field and loads the results screen
     * 
     */
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
