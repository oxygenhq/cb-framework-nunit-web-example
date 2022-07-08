using CloudBeat.Frameworks.NUnit;
using CloudBeat.Frameworks.NUnit.Attributes;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;

namespace NUnitWebExample.Tests
{
    [CbNUnitTest]
    public class BaseTest
    {
		protected EventFiringWebDriver driver;

		public BaseTest()
		{
		}

		[OneTimeSetUp]
		public void Init()
		{
			//Debugger.Launch();
			driver = new EventFiringWebDriver(new ChromeDriver());
			CbNUnit.WrapWebDriver(driver);
		}

		[OneTimeTearDown]
		public void Cleanup()
		{
			if (driver != null)
			{
				driver.Quit();
			}
		}
	}
}
