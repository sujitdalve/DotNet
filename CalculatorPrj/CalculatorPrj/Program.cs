namespace CalculatorPrj
{
    public interface ICalculator
    {
        int add(int x, int y);
        int subtract(int x, int y);

        int multiply(int x, int y);
        int divide(int x, int y);
        string message(string name);
    }

    public class Calculator : ICalculator
    {
        public int add(int x, int y) { return x + y; }
        public int subtract(int x, int y) { return x - y; }
        public int multiply(int x, int y) { return x * y; }
        public int divide(int x, int y) { return x / y; }

        public string message(string name) { return "Hello " + name; }
    }





}

