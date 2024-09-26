namespace Lesson6_DZ
{

    internal class Calculator : ICalculator
    {
        public double Result;

        public event EventHandler<EventArgs>? GotResult;

        private Stack<double> stack = new Stack<double>();

        private Stack<CalculatorActionLog> actions = new Stack<CalculatorActionLog>();

        public void Divide(int x)
        {
            if (x == 0)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Divide, x));
                throw new CalculatorDivideByZeroException("Делить на 0 нельзя!", actions);
            }

            stack.Push(Result);
            Result /= x;
            RaiseEvent();
        }

        public void Divide(double x)
        {
            if (x == 0)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Divide, x));
                throw new CalculatorDivideByZeroException("Делить на 0 нельзя!", actions);
            }

            stack.Push(Result);
            Result /= x;
            RaiseEvent();
        }

        public void Multiply(int x)
        {
            var temp = x * Result;

            if (temp > int.MaxValue)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Multiply, x));
                throw new CalculateOperationCauseOverflowException("Переполнение типа!", actions);
            }
            stack.Push(Result);
            Result *= x;
            RaiseEvent();

        }

        public void Multiply(double x)
        {
            var temp = x * Result;

            if (temp > int.MaxValue)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Multiply, x));
                throw new CalculateOperationCauseOverflowException("Переполнение типа!", actions);
            }
            stack.Push(Result);
            Result *= x;
            RaiseEvent();

        }

        public void Subtract(int x)
        {
            var temp = Result - x;

            if (temp < int.MinValue)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Subtract, x));
                throw new CalculateOperationCauseOverflowException("Переполнение типа!", actions);
            }
            stack.Push(Result);
            Result -= x;
            RaiseEvent();

        }

        public void Subtract(double x)
        {
            var temp = Result - x;

            if (temp < int.MinValue)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Subtract, x));
                throw new CalculateOperationCauseOverflowException("Переполнение типа!", actions);
            }
            stack.Push(Result);
            Result -= x;
            RaiseEvent();

        }

        public void Sum(int x)
        {
            ulong temp = (ulong)(x + Result);

            if (temp > int.MaxValue)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Sum, x));
                throw new CalculateOperationCauseOverflowException("Переполнение типа!", actions);
            }
            stack.Push(Result);
            Result += x;
            RaiseEvent();

        }

        public void Sum(double x)
        {
            ulong temp = (ulong)(x + Result);

            if (temp > int.MaxValue)
            {
                actions.Push(new CalculatorActionLog(CalculatorAction.Sum, x));
                throw new CalculateOperationCauseOverflowException("Переполнение типа!", actions);
            }
            stack.Push(Result);
            Result += x;
            RaiseEvent();

        }
        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                Console.WriteLine("Отмена последней удачной операции калькулятора > ");
                Result = stack.Pop();
                RaiseEvent();
            }
        }

        private void RaiseEvent()
        {
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }
}
