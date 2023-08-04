namespace NUnitProject
{
    [TestFixture]
    internal class AssertionsTest
    {
        [SetUp]
        public void SetUp()
        {
            Console.WriteLine("The beginning of test");
        }

        [Test, Category("equality")]
        public void AreStringsEqual()
        {
            string firstString = "I want to eat";
            string secondString = "I want to eat";
            Assert.That(firstString, Is.EqualTo(secondString), "Strings are not equal");
        }

        [Test, Category("equality")]
        public void AreListsEqual()
        {
            List<string> firstList = new() { "I", "want", "to", "eat" };
            List<string> secondList = new() { "I", "want", "to", "eat" };
            CollectionAssert.AreEqual(firstList, secondList, "Lists are not equal");
        }

        [Test(Description = "Check if sting is in the list")]
        public void IsStringInList()
        {
            List<string> list = new() { "I", "want", "to", "eat" };
            string expectedString = "want";
            Assert.Contains(expectedString, list, $"The expected string '{expectedString}' is not in the list");
        }

        [Test, Description("Check if first number is bigger than second one")]
        public void IsNumberBigger()
        {
            int a = 10;
            int b = 5;
            Assert.That(a, Is.GreaterThan(b), $"{a} is not bigger than {b}");
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("The end of test");
        }
    }
}
