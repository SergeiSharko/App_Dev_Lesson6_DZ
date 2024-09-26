namespace Lesson6_DZ
{
    internal class CalculateOperationCauseOverflowException : CalculatorException
    {
        public CalculateOperationCauseOverflowException(string message, Stack<CalculatorActionLog> calculatorActionLogs) : base(message, calculatorActionLogs)
        {

        }

        public CalculateOperationCauseOverflowException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
