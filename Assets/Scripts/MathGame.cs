using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MathGame : MonoBehaviour
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
    private TextMeshProUGUI _output;
    [SerializeField]
    private TextMeshProUGUI _timer;
    [SerializeField]
    private float _countdownDuration = 180f;
    private float _currentTime;

    private Coroutine _gameLoop;
    private int _answer;
    private int _score = 0;
    void Start()
    {
        NewGame();
        _currentTime = _countdownDuration;
        UpdateTimerDisplay(_currentTime);
        _gameLoop = StartCoroutine(StartTimer());
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
                _score++;
                _output.text = "Score: " + _score;
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

    private IEnumerator StartTimer()
    {
        Debug.Log("Timer starting!");
        // Countdown loop
        while (_currentTime > 0f)
        {
            // Wait for 1 second
            yield return new WaitForSeconds(1f);
            UpdateTimerDisplay(--_currentTime);
        }

        // Timer has reached 0, handle game over 
        HandleGameOver();
    }

    private void HandleGameOver()
    {
        Debug.Log("Game Over!");
        _input.gameObject.SetActive(false);
        StopCoroutine(_gameLoop);
    }
    public void UpdateTimerDisplay(float currentTime)
    {
        // Format the time as minutes:seconds
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        _timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
