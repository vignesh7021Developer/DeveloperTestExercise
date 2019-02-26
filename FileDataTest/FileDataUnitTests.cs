using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileData;
using Microsoft.QualityTools.Testing.Fakes;

namespace FileDataTest
{
    [TestClass]
    public class FileDataUnitTests
    {
        IRepository _repository;
        IParser _parser ;
        ICommandLineUtility _fileUtility;
        string[] args;
        public FileDataUnitTests()
        {
            _repository = new FileDataRepository();
            _parser = new CommandLineParser(_repository);
            _fileUtility = new FileDataUtility(_parser,_repository);

        }
        
        [TestMethod]
        public void TestValidate()
        {
            using (ShimsContext.Create())
            {
                args = new string[] {"-v","c:\test.txt" };
                FileDataResult result = _fileUtility.Validate(args);
                Assert.IsTrue(result.Status);
            }
        }

        [TestMethod]
        public void TestValidateForNoArgs()
        {
            using (ShimsContext.Create())
            {
                args = new string[] { };
                FileDataResult result = _fileUtility.Validate(args);
                Assert.IsFalse(result.Status);
            }
        }

        [TestMethod]
        public void TestValidateForInvalidArgs()
        {
            using (ShimsContext.Create())
            {
                args = new string[] {"a" };
                FileDataResult result = _fileUtility.Validate(args);
                Assert.IsFalse(result.Status);
            }
        }

        [TestMethod]
        public void TestValidateForVersion()
        {
            using (ShimsContext.Create())
            {
                args = new string[] { "-v","c:\abc.text" };
                FileDataResult result = _fileUtility.Validate(args);
                Assert.IsTrue(result.Status);
            }
        }

        [TestMethod]
        public void TestValidateForSize()
        {
            using (ShimsContext.Create())
            {
                args = new string[] { "-v", "c:\abc.text" };
                FileDataResult result = _fileUtility.Validate(args);
                Assert.IsTrue(result.Status);
            }
        }


    }
}
