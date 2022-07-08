using CloudBeat.Frameworks.NUnit;
using CloudBeat.Frameworks.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Reflection;

namespace NUnitWebExample.Tests
{
    //[Parallelizable(ParallelScope.Fixtures)]
    [CbNUnitTest]
    public class ExampleTest : BaseTest
    {
        private const string SITE_URL = @"http://automationpractice.com/index.php";

        public ExampleTest() : base() { }

        [Test(Description = "Test"), Category("Menu")]
        [Property("Foo", "Bar")]
        [Property("NotFoo", "Bar")]
        public void Test1()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var linkText = "DRESSES";
            driver.Navigate().GoToUrl(SITE_URL);
            var link = driver.FindElement(By.PartialLinkText(linkText));
            link.Click();
            CbNUnit.Step("customStep", () =>
            {
                var link2 = driver.FindElement(By.Id("layered_category_11"));
                link2.Click();

                var link3 = driver.FindElement(By.PartialLinkText("Yellow"));
                link3.Click();
            });
            var link4 = driver.FindElement(By.Id("layered_id_attribute_group_16"));
            link4.Click();
        }

       // [Test, Order(41), Description("הפינוקים שלי - לחישוב הפינוקים"), Category("Category Test")]
        [Property("Foo", "Bar")]
        public void TestMax()
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var linkText = "DRESSES";
            driver.Navigate().GoToUrl(SITE_URL);
            var link = driver.FindElement(By.PartialLinkText(linkText));
            link.Click();

            var link2 = driver.FindElement(By.Id("layered_category_11"));
            link2.Click();

            var link3 = driver.FindElement(By.PartialLinkText("Yellow"));
            link3.Click();

            var link4 = driver.FindElement(By.Id("layered_id_attribute_group_16"));
            link4.Click();
        }
        

        [Test(Description = "Category test 1"), Category("Category Test NEW2")]
        public void TestCat1()
        {
        }

        [Test(Description = "Category test 2"), Category("Category Test")]
        public void TestCat2()
        {
        }

        [Test(Description = "Test: Test + 2 TestCase single param"), Category("Menu")]
        [TestCase("param1", Description = "TestCase: Test + 2 TestCase single param: 1")]
        [TestCase("param2", Description = "TestCase: Test + 2 TestCase single param and cat: 2", Category = "testcase cat")]
        public void Test2(string param)
        {
        }

        public enum Test_Type
        {
            Identified,
            NotIdentified,
        }
        [Test(Description = "Test: Test + 2 TestCase mult params"), Category("Menu")]
        [TestCase("param1", 4, Test_Type.Identified, Description = "TestCase: Test + 2 TestCase mult params: 1")]
        [TestCase("param2", 6, Test_Type.NotIdentified, Description = "TestCase: Test + 2 TestCase mult params: 2")]
        public void Test3(string param, int param2, Test_Type testType)
        {
        }

        /*
        static object[] Source =
        {
            new object[] { 12, 3, 4 },
            new object[] { 12, 2, 6 }
        };
        [Test(Description = "Test: Test + TestCaseSource initialized array"), Category("test case source main cat")]
        [TestCaseSource(nameof(Source), Category = "test case source category")]
        public void Test4a(int a, int b, int c)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }

        static List<string> ExampleSource()
        {
            return new List<string>();
        }
        [Test(Description = "Test: Test + TestCaseSource LIST"),]
        [TestCaseSource(nameof(ExampleSource))]
        public void Test4b(string ExampleSource)
        {
            TestContext.Progress.WriteLine("Executing method: " + MethodBase.GetCurrentMethod().Name);
            var logo = driver.FindElement(MobileBy.Id("com.niksoftware.snapseed:id/logo_view"));
        }*/

        [Test(Description = "Test ordered (order 1)"), Category("Ordered"), Order(1)]
        public void Test5()
        {
        }

        [Test(Description = "Test ordered (order 3)"), Category("Ordered"), Order(3)]
        public void Test6()
        {
        }

        [Test(Description = "Test Failing (order 2)"), Category("Ordered"), Order(2)]
        public void Test7()
        {
        }

        [Test(Description = "Nested steps")]
        public void Test8()
        {
        }

        [Test]
        [TestCase("paramA", 4, Test_Type.Identified)]
        [TestCase("paramB", 6, Test_Type.NotIdentified)]
        public void TestNoDescription(string param, int param2, Test_Type testType)
        {

        }
    }
}
