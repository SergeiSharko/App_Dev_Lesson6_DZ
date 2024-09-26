namespace Lesson6_DZ
{
    //Доработайте реализацию калькулятора разработав собственные типы ошибок.
    //CalculatorDivideByZeroException, CalculateOperationCauseOverflowException


    //Реализуйте класс - список, описывающий последовательность действий приведших исключению.
    //Очевидно что класс калькулятора должен быть доработан чтобы хранить не только информацию 
    //необходимую нам для отмены но и информацию о самом действии.

    //ДЗ - Доработайте класс калькулятора способным работать как с целочисленными так и с дробными числами. (возможно стоит задействовать перегрузку операций).

    internal class Program
    {
        static void Calculator_GotResult(object sender, EventArgs e)
        {
            Console.WriteLine($"Результат оперции = {((Calculator)sender).Result}");

        }

        static void Execute(Action<int> action, int value = 10)
        {
            try
            {
                action.Invoke(value);
            }
            catch (CalculatorDivideByZeroException ex)
            {
                Console.WriteLine(ex.LastOpertionWithExeption());
            }
            catch (CalculateOperationCauseOverflowException ex)
            {
                Console.WriteLine(ex.LastOpertionWithExeption());
            }
        }


        static void Main(string[] args)
        {
            ICalculator calculator = new Calculator();

            calculator.GotResult += Calculator_GotResult;

            Execute(calculator.Sum, int.MaxValue);
            Execute(calculator.Sum, 5);
            Execute(calculator.Multiply);
            calculator.CancelLast();
            Execute(calculator.Subtract, int.MaxValue);
            Execute(calculator.Subtract);
            Execute(calculator.Sum, int.MaxValue);
            calculator.Sum(10);
            calculator.Divide(4);
            calculator.CancelLast();            
            Execute(calculator.Divide, 0);
        }
    }
}
