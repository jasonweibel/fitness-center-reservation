using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FCR.BLL.Tests
{
    [TestClass]
    public abstract class AAA
    {
        public abstract void Arrange();
        public abstract void Act();
        public virtual void CleanUp() { }
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void MainSetup()
        {
            Arrange();
            Act();
        }

        [TestCleanup]
        public void MainTeardown()
        {
            CleanUp();
        }

    }
}
