using Films.Kernel.Managers.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Films.Kernel.Managers.Tests
{
    [TestClass]
    public class TestLog
    {
        [TestMethod]
        public void Log()
        {
            Injector.Configs.TurnLog = true;
            Injector.Configs.Debug = false;
            Injector.Configs.LogFileName = "test-log.txt";

            var log = Injector.CreateLog();
            log.Info("TAG", "message");
            log.Warning("TAG", "message");
            log.Error("TAG", new Exception("message"));

            Injector.Configs.Debug = true;
            log = Injector.CreateLog();
            var exception = new InternalManagerException("message");

            try
            {
                log.Error("TAG", exception);
                Assert.Fail();
            }
            catch (InternalManagerException ex)
            {
                Assert.AreEqual(exception, ex);
            }
        }
    }
}
