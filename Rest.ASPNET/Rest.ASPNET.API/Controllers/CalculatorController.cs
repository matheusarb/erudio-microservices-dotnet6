using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Rest.ASPNET.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);            
            return Ok($"Sum result: {RoundResult(sum).ToString(CultureInfo.InvariantCulture)}");
        }

        return BadRequest("Invalid data");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult Subtraction(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);            
            return Ok($"Sum result: {RoundResult(sum).ToString(CultureInfo.InvariantCulture)}");
        }

        return BadRequest("Invalid data");
    }
    
    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult Multiplication(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);            
            return Ok($"Sum result: {RoundResult(sum).ToString(CultureInfo.InvariantCulture)}");
        }

        return BadRequest("Invalid data");
    }
    
    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult Division(string firstNumber, string secondNumber)
    {
        if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
        {
            var sum = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);            
            return Ok($"Sum result: {RoundResult(sum).ToString(CultureInfo.InvariantCulture)}");
        }

        return BadRequest("Invalid data");
    }

    [HttpGet("square-root/{number}")]
    public IActionResult SquareRoot(string number)
    {
        if(IsNumeric(number))
        {
            var squareRoot = Math.Sqrt((double)ConvertToDecimal(number));
            return Ok(squareRoot);
        }

        return BadRequest("Invalid data");
    }
    private decimal ConvertToDecimal(string strNumber)
    {
        decimal decimalVal; 
        if(decimal.TryParse(strNumber,
            NumberStyles.Any,
            CultureInfo.InvariantCulture,
            out decimalVal))
            return decimalVal;
        return 0;
    }

    private bool IsNumeric(string strNumber)
    {
        double isDouble;
        var parse = double.TryParse(
            strNumber,out isDouble);
        
        if (parse)
            return true;
        return false;
    }

    private decimal RoundResult(decimal result)
        => Math.Round(result, 3);
    
}
