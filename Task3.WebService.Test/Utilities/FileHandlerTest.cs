using Task3.WebService.Model;
using Task3.WebService.Utilities;

namespace Task3.WebService.Test.Utilities
{
    [TestFixture]
    public class FileHandlerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task LoadJsonFileTest()
        {
            //Arrange
            var filePath = @"C://hotelsrates.json";
            //Act
            var result = new JsonHandler().LoadJsonFile(filePath);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Not.Empty);
        }

        [Test]
        public async Task ReadJsonTest()
        {
            //Arrange
            var filePath = @"C://hotelsrates.json";
            //Act
            var json = new JsonHandler().LoadJsonFile(filePath);
            var result = new JsonHandler().ReadJson<List<HotelsRates>>(json);
            //Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count > 0);
        }
    }
}