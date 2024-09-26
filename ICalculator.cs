namespace Lesson6_DZ
{
    internal interface ICalculator
    {
        event EventHandler<EventArgs> GotResult;
        void Sum(int x);
        void Subtract(int x);
        void Multiply(int x);
        void Divide(int x);

        void CancelLast();

    }
}
