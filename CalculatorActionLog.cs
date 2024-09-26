namespace Lesson6_DZ
{
    internal class CalculatorActionLog
    {
        public CalculatorAction CalculatorAction { get; private set; }
        public double CalculatorArgument { get; private set; }

        public CalculatorActionLog(CalculatorAction calculatorAction, double calculatorArgument)
        {
            this.CalculatorAction = calculatorAction;
            this.CalculatorArgument = calculatorArgument;
        }
    }
}
