using Microsoft.Extensions.Options;
using Moq;
using Task3.WebService.Configs;
using Task3.WebService.Repositories;
using Task3.WebService.Utilities;

namespace Task3.WebService.Test.Repositories
{
    [TestFixture]
    public class HotelRateRepositoryTest
    {
        private Mock<IJsonHandler> moqJsonHandler;

        [OneTimeSetUp]
        public void SetupMockJsonHandler()
        {
            moqJsonHandler = new Mock<IJsonHandler>();
            moqJsonHandler.Setup(m => m.LoadJsonFile(It.IsAny<string>()))
            .Returns("Json Content");
            moqJsonHandler.Setup(m => m.ReadJson<It.IsAnyType>(It.IsAny<string>()))
            .Returns((string json) => MockDataHandler.GenerateMockHotelsRates());
            MockDataHandler.GenerateMockHotelsRates();
        }


        [Test]
        [TestCase(0, "2016-10-15")]
        public async Task FindAllByHotelIdAndTargetDay_ZeroIdTest(int hotelId, DateTime targetDay)
        {
            //Arrange
            var hotelRateRepository = new HotelRateRepository(moqJsonHandler.Object, Options.Create(new Files()));

            //Act
            var result = hotelRateRepository.FindAllByHotelIdAndTargetDay(hotelId, targetDay);

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task FindAllByHotelIdAndTargetDay()
        {
            //Arrange
            var hotelRateRepository = new HotelRateRepository(moqJsonHandler.Object, Options.Create(new Files()));
            var hotelItem = MockDataHandler.MoqHotelRates.FirstOrDefault();
            var hotelId = hotelItem.hotel.hotelID;
            var targetDate = hotelItem.hotelRates.FirstOrDefault().targetDay;

            //Act
            var result = hotelRateRepository.FindAllByHotelIdAndTargetDay(hotelId, targetDate);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Count > 0);
            Assert.That(result.All(r => r.targetDay == targetDate), Is.True);
            Assert.That(result.Count == hotelItem.hotelRates.Count(r => r.targetDay == targetDate));
        }
    }
}
