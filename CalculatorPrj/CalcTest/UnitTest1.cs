
using CalculatorPrj;

namespace CalcTest
{
    public class Tests
    {
        //Declarations
        ICalculator obj;

        // Annotations -[] for compiler to know
        [SetUp]
        public void Setup()
        {
            obj = new Calculator();
        }

        [Test]
        public void TestAdd()
        {
            // 3A's - Assign,Act,and Assert
            int actualresult = obj.add(4, 5);
            int expectedresult = 9;
            Assert.AreEqual(expectedresult, actualresult);
        }


        [Test]
        public void TestMult()
        {
            // 3A's - Assign,Act,and Assert
            int actualresult = obj.multiply(4, 5);
            int expectedresult = 20;
            Assert.AreEqual(expectedresult, actualresult);
        }
        [Test]
        public void TestMessage()
        {
            string actualresult = obj.message("Ram");
            Assert.AreEqual("Hello Ram", actualresult);
        }
    }
}