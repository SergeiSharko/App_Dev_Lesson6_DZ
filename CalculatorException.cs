namespace Lesson6_DZ
{
    internal class CalculatorException : Exception
    {
        public Stack<CalculatorActionLog> calculatorActionLogs { get; private set; }
        public CalculatorException(string? message, Stack<CalculatorActionLog> calculatorActionLogs) : base(message)
        {
            this.calculatorActionLogs = calculatorActionLogs;
        }

        public CalculatorException(string message, Exception ex) : base(message)
        {

        }

        public string LastOpertionWithExeption()
        {
            var lastOp = calculatorActionLogs.Peek();
            return $"{Message} | Параметры, вызвавшие исключение: Действие = {lastOp.CalculatorAction}, Значение аргумента = {lastOp.CalculatorArgument}";

        }

        public override string ToString()
        {
            return Message + " | " + string.Join("\n", calculatorActionLogs.Select(x => $"Параметры, вызвавшие исключение: Действие = {x.CalculatorAction}, Значение аргумента = {x.CalculatorArgument}"));
        }
    }
}
