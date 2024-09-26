namespace Lesson6_DZ
{
    internal class CalculatorDivideByZeroException : CalculatorException
    {
        public CalculatorDivideByZeroException(string message, Stack<CalculatorActionLog> calculatorActionLogs) : base(message, calculatorActionLogs)
        {

        }

        public CalculatorDivideByZeroException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
