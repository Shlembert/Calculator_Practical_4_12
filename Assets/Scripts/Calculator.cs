using TMPro;
using UnityEngine;

public class Calculator : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputNum1, inputNum2;
    [SerializeField] private TMP_Text resultText, exceptionText;

    private int num1, num2;
    private float result;

    private void ResetException()
    {
        exceptionText.text = resultText.text = string.Empty;
    }

    public void ClearText()
    {
        exceptionText.text = resultText.text = inputNum1.text = inputNum2.text = string.Empty;
    }

    private void ExceptionPrint(string message)
    {
        exceptionText.text = $"Ошибка: {message} введенное значение не является целым числом или не введено.";
    }

    private void ConvertInput()
    {
        if (!int.TryParse(inputNum1.text, out num1)){ ExceptionPrint("Первое"); return;}
        if (!int.TryParse(inputNum2.text, out num2)){ ExceptionPrint("Второе"); return;}
    }

    private void PrintResult()
    {
        resultText.text = result.ToString();
    }

    public void Calculate(string operation)
    {
        ResetException();
        ConvertInput();

        switch (operation)
        {
            case "+": Summation();
                break;
            case "-": Subtraction();
                break;
            case "*": Multiplication();
                break;
            case "/": Division();
                break;
        }
        PrintResult();
    }

    private void Summation() { result = num1 + num2;}
    private void Subtraction() { result = num1 - num2;}
    private void Multiplication() { result = num1 * num2;}
    private void Division() { result = (float)num1 / (float)num2;}

    public void Compare()
    {
        ResetException();
        ConvertInput();

        if (num1>num2) resultText.text = $"{num1} > {num2}";
        else if(num2>num1) resultText.text = $"{num1} < {num2}";
        else resultText.text = $"{num1} = {num2}"; 
    }
}
